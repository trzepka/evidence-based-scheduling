# CoffeeScript
class App.UserScheduleGraph
    constructor: (@parentTagId, @data, @showUnassignedTasks) ->
    
    draw: () -> 
        @init()
        @doDraw()
        func = () => @doDraw()
        setInterval(func, 500)
    
    init: () ->
        margin = {top: 20, right: 20, bottom: 30, left: 60}
        maxUserNameLength = d3.max(@data, (d) -> d.user.name.length)*6;
        margin.left = maxUserNameLength + 5;
        @startDate = new Date()
        @width = 960 - margin.left - margin.right
        @height = 500 - margin.top - margin.bottom
        @svg = d3
            .select('#'+@parentTagId)
            .append("svg")
                .attr("width", @width + margin.left + margin.right)
                .attr("height", @height + margin.top + margin.bottom)
            .append("g")
                .attr("transform", "translate(" + margin.left + "," + margin.top + ")");
        @initAxes()

    initAxes: () ->
        x = d3.time.scale()
            .domain([@startDate, d3.time.day.offset(@startDate, d3.max(@data, (d) -> d.stats.max) + 2)])
            .range([0, @width]);

        y = d3.scale.ordinal()
        .domain(d3.map(@data, (d) -> d.user.name).keys())
        .rangePoints([0, @height], 1)
        
        @xAxis = d3.svg.axis()
            .scale(x)
            .orient("bottom")
            .tickFormat(d3.time.format('%b %e'));

        @yAxis = d3.svg.axis()
            .scale(y)
            .orient("left")
            .ticks(10);
        
        @svg
            .append("g")
            .attr("class", "axis x.axis")
            .attr("transform", "translate(0," + @height + ")")
            .call(@xAxis);

        @svg.append("g")
            .attr("class", "y axis")
            .call(@yAxis)
        .append("text")
            .attr("transform", "rotate(-90)")
            .attr("y", 6)
            .attr("dy", ".71em")
            .style("text-anchor", "end")
            .text("Developers");
    
        
    doDraw: () ->
        format = d3.time.format("%Y-%m-%d");            
        @dataForDrawing = @data.filter((d) => @showUnassignedTasks is true or (@showUnassignedTasks is false and d.user.name != "Unassigned"))
        x = d3.time.scale()
            .domain([@startDate, d3.time.day.offset(@startDate, d3.max(@dataForDrawing, (d) -> d.stats.max) + 2)])
            .range([0, @width]);

        y = d3.scale.ordinal()
        .domain(d3.map(@dataForDrawing, (d) -> d.user.name).keys())
        .rangePoints([0, @height], 1)

        @yAxis = d3.svg.axis()
            .scale(y)
            .orient("left")
            .ticks(10);
        @svg.selectAll(".y.axis")
            .transition()
            .duration(500)
            .call(@yAxis)

        @svg.selectAll(".x.axis")
            .call(@xAxis);
        
        @drawBar(x, y, @startDate)
        @drawFrontWhisker(x, y, @startDate)
        @drawBackWhisker(x, y, @startDate)
        
        median = @svg.selectAll("line.median")
            .data(@dataForDrawing.filter((d) -> d.stats.median != d.stats.quartile1 and d.stats.median != d.stats.quartile3))
        median.transition()
            .duration(500)
            .attr("y1", (d) -> y(d.user.name) - 10)
            .attr("y2", (d) -> y(d.user.name) + 10)
        median.exit().remove()    
        median.enter()
            .append("line")
                .attr("class", "median")
                .attr("x1", (d) => @getCoordinateFromDate(x, @startDate, d.stats.median))
                .attr("x2", (d) => @getCoordinateFromDate(x, @startDate, d.stats.median))
                .attr("y1", (d) -> y(d.user.name) - 10)
                .attr("y2", (d) -> y(d.user.name) + 10)
                
    drawBar: (xscale, yscale, @startDate) ->
        initialXStart = (d) => @getCoordinateFromDate(xscale, @startDate, d.stats.quartile1)
        initialXEnd = (d) => @getCoordinateFromDate(xscale, @startDate, d.stats.quartile3)
        
        xstart = (d) -> if d.stats.quartile1 == d.stats.median && d.stats.quartile3 == d.stats.median then initialXStart(d) - 3 else initialXStart(d)
        xend = (d) -> if d.stats.quartile1 == d.stats.median && d.stats.quartile3 == d.stats.median then initialXEnd(d) + 3 else initialXEnd(d)
        bar = @svg.selectAll("rect.bar")
            .data(@dataForDrawing);
        bar.transition()
            .duration(500)
            .attr("y", (d) -> yscale(d.user.name) - 10);

        bar.enter()
            .append("rect")
            .attr("class", "bar")
            .attr("x", (d) -> xstart(d))
            .attr("height", 20)
            .attr("y", (d) -> yscale(d.user.name) - 10)
            .attr("width", (d) => xend(d) - xstart(d));

        bar.exit()
            .attr('opacity', 1)
            .transition()
            .duration(500)
            .attr('opacity', 1e-6)
            .each('end', () -> d3.select(this).remove());

    drawFrontWhisker: (xscale, yscale, @startDate) ->
        frontWhisker = @svg.selectAll("g.front-whisker")
            .data(@dataForDrawing);
        lineStart = (d) -> d.stats.min
        lineEnd = (d) -> d.stats.quartile1
        x = (d, func) =>  @getCoordinateFromDate(xscale, @startDate, func(d))
        conditionalLineStart = (d) -> if lineStart(d) == lineEnd(d) then x(d, lineStart) - 6 else x(d, lineStart)
        frontWhisker
            .transition()
            .duration(500)
            .attr("transform", (d) -> "translate("+conditionalLineStart(d)+", "+(yscale(d.user.name) - 10)+")")
        frontWhisker.exit().remove()
        whiskerGraphics = frontWhisker
            .enter()
            .append("g")
            .attr("class", 'front-whisker')
            .attr("transform", (d) -> "translate("+conditionalLineStart(d)+", "+(yscale(d.user.name) - 10)+")")
        whiskerGraphics.append("line")
                .attr("class", "whisker")
                .attr("x1", 0)
                .attr("x2", (d) => @getCoordinateFromDate(xscale, @startDate, lineEnd(d)) - conditionalLineStart(d))
                .attr("y1", 10)
                .attr("y2", 10)
        whiskerGraphics.append("line")
                .attr("class", "whisker")
                .attr("x1", 0)
                .attr("x2", 0)
                .attr("y1", 0)
                .attr("y2", 20)
    
    drawBackWhisker: (xscale, yscale, @startDate) ->
        backWhisker = @svg.selectAll("g.back-whisker")
            .data(@dataForDrawing);
        lineStart = (d) -> d.stats.quartile3
        lineEnd = (d) -> d.stats.max
        x = (d, func) =>  @getCoordinateFromDate(xscale, @startDate, func(d))
        conditionalLineEnd = (d) -> if lineStart(d) == lineEnd(d) then x(d, lineEnd) + 6 else x(d, lineEnd)
        backWhisker
            .transition()
            .duration(500)
            .attr("transform", (d) => "translate("+@getCoordinateFromDate(xscale, @startDate, lineStart(d))+", "+(yscale(d.user.name) - 10)+")")
        whiskerGraphics = backWhisker
            .enter()
            .append("g")
            .attr("class", 'back-whisker')
            .attr("transform", (d) => "translate("+@getCoordinateFromDate(xscale, @startDate, lineStart(d))+", "+(yscale(d.user.name) - 10)+")")
        backWhisker.exit().remove()
        whiskerGraphics.append("line")
                .attr("class", "whisker")
                .attr("x1", 0)
                .attr("x2", (d) => conditionalLineEnd(d) - @getCoordinateFromDate(xscale, @startDate, lineStart(d)))
                .attr("y1", 10)
                .attr("y2", 10)
        whiskerGraphics.append("line")
                .attr("class", "whisker")
                .attr("x1", (d) => conditionalLineEnd(d) - @getCoordinateFromDate(xscale, @startDate, lineStart(d)))
                .attr("x2", (d) => conditionalLineEnd(d) - @getCoordinateFromDate(xscale, @startDate, lineStart(d)))
                .attr("y1", 0)
                .attr("y2", 20)
        
    getCoordinateFromDate: (scale, @startDate, days) ->
        scale(d3.time.day.offset(@startDate, days))