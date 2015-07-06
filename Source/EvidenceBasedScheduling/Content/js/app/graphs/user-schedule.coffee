# CoffeeScript
class App.UserScheduleGraph
    constructor: (@parentTagId, @data) ->
    
    draw: () ->
        format = d3.time.format("%Y-%m-%d");            

        startDate = new Date()
        margin = {top: 20, right: 20, bottom: 30, left: 60}
        maxUserNameLength = d3.max(@data, (d) -> d.user.name.length)*6;
        margin.left = maxUserNameLength + 5;
        width = 960 - margin.left - margin.right
        height = 500 - margin.top - margin.bottom
        @svg = d3
            .select('#'+@parentTagId)
            .append("svg")
                .attr("width", width + margin.left + margin.right)
                .attr("height", height + margin.top + margin.bottom)
            .append("g")
                .attr("transform", "translate(" + margin.left + "," + margin.top + ")");
        x = d3.time.scale()
            .domain([startDate, d3.time.day.offset(startDate, d3.max(@data, (d) -> d.stats.max) + 2)])
            .range([0, width]);

        y = d3.scale.ordinal()
        .domain(d3.map(@data, (d) -> d.user.name).keys())
        .rangePoints([0, height], 1)
        
        xAxis = d3.svg.axis()
            .scale(x)
            .orient("bottom")
            .tickFormat(d3.time.format('%b %e'));

        yAxis = d3.svg.axis()
            .scale(y)
            .orient("left")
            .ticks(10);
        
        @svg.append("g")
            .attr("class", "x axis")
            .attr("transform", "translate(0," + height + ")")
            .call(xAxis);

        @svg.append("g")
            .attr("class", "y axis")
            .call(yAxis)
        .append("text")
            .attr("transform", "rotate(-90)")
            .attr("y", 6)
            .attr("dy", ".71em")
            .style("text-anchor", "end")
            .text("Developers");
        @drawBar(x, y, startDate)
        @drawFrontWhisker(x, y, startDate)
        @drawBackWhisker(x, y, startDate)
        
        @svg.selectAll(".median")
            .data(@data.filter((d) -> d.stats.median != d.stats.quartile1 and d.stats.median != d.stats.quartile3))
            .enter()
            .append("line")
                .attr("class", "median")
                .attr("x1", (d) => @getCoordinateFromDate(x, startDate, d.stats.median))
                .attr("x2", (d) => @getCoordinateFromDate(x, startDate, d.stats.median))
                .attr("y1", (d) -> y(d.user.name) - 10)
                .attr("y2", (d) -> y(d.user.name) + 10)
                
    drawBar: (xscale, yscale, startDate) ->
        initialXStart = (d) => @getCoordinateFromDate(xscale, startDate, d.stats.quartile1)
        initialXEnd = (d) => @getCoordinateFromDate(xscale, startDate, d.stats.quartile3)
        
        xstart = (d) -> if d.stats.quartile1 == d.stats.median && d.stats.quartile3 == d.stats.median then initialXStart(d) - 3 else initialXStart(d)
        xend = (d) -> if d.stats.quartile1 == d.stats.median && d.stats.quartile3 == d.stats.median then initialXEnd(d) + 3 else initialXEnd(d)
        @svg.selectAll(".bar")
            .data(@data)
            .enter()
            .append("rect")
                .attr("class", "bar")
                .attr("x", (d) -> xstart(d))
                .attr("height", 20)
                .attr("y", (d) -> yscale(d.user.name) - 10)
                .attr("width", (d) => xend(d) - xstart(d));
    

    drawFrontWhisker: (xscale, yscale, startDate) ->
        frontWhisker = @svg.selectAll(".front-whisker")
            .data(@data)
            .enter();
        lineStart = (d) -> d.stats.min
        lineEnd = (d) -> d.stats.quartile1
        x = (d, func) =>  @getCoordinateFromDate(xscale, startDate, func(d))
        conditionalLineStart = (d) -> if lineStart(d) == lineEnd(d) then x(d, lineStart) - 6 else x(d, lineStart)
        frontWhisker.append("line")
                .attr("class", "whisker")
                .attr("x1", (d) => conditionalLineStart(d))
                .attr("x2", (d) => @getCoordinateFromDate(xscale, startDate, lineEnd(d)))
                .attr("y1", (d) -> yscale(d.user.name))
                .attr("y2", (d) -> yscale(d.user.name))
        frontWhisker.append("line")
                .attr("class", "whisker")
                .attr("x1", (d) => conditionalLineStart(d))
                .attr("x2", (d) => conditionalLineStart(d))
                .attr("y1", (d) -> yscale(d.user.name) - 10)
                .attr("y2", (d) -> yscale(d.user.name) + 10)
    
    drawBackWhisker: (xscale, yscale, startDate) ->
        backWhisker = @svg.selectAll(".back-whisker")
            .data(@data)
            .enter();
        lineStart = (d) -> d.stats.quartile3
        lineEnd = (d) -> d.stats.max
        x = (d, func) =>  @getCoordinateFromDate(xscale, startDate, func(d))
        conditionalLineEnd = (d) -> if lineStart(d) == lineEnd(d) then x(d, lineEnd) + 6 else x(d, lineEnd)
        backWhisker.append("line")
                .attr("class", "whisker")
                .attr("x1", (d) => @getCoordinateFromDate(xscale, startDate, lineStart(d)))
                .attr("x2", (d) => conditionalLineEnd(d))
                .attr("y1", (d) -> yscale(d.user.name))
                .attr("y2", (d) -> yscale(d.user.name))
        backWhisker.append("line")
                .attr("class", "whisker")
                .attr("x1", (d) => conditionalLineEnd(d))
                .attr("x2", (d) => conditionalLineEnd(d))
                .attr("y1", (d) -> yscale(d.user.name) - 10)
                .attr("y2", (d) -> yscale(d.user.name) + 10)
        
    getCoordinateFromDate: (scale, startDate, days) ->
        scale(d3.time.day.offset(startDate, days))