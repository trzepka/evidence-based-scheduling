(function() {
  App.UserScheduleGraph = (function() {
    function UserScheduleGraph(parentTagId, data) {
      this.parentTagId = parentTagId;
      this.data = data;
    }

    UserScheduleGraph.prototype.draw = function() {
      var format, height, margin, startDate, width, x, xAxis, y, yAxis;
      format = d3.time.format("%Y-%m-%d");
      startDate = new Date();
      margin = {
        top: 20,
        right: 20,
        bottom: 30,
        left: 60
      };
      width = 960 - margin.left - margin.right;
      height = 500 - margin.top - margin.bottom;
      this.svg = d3.select('#' + this.parentTagId).append("svg").attr("width", width + margin.left + margin.right).attr("height", height + margin.top + margin.bottom).append("g").attr("transform", "translate(" + margin.left + "," + margin.top + ")");
      x = d3.time.scale().domain([
        startDate, d3.time.day.offset(startDate, d3.max(this.data, function(d) {
          return d.stats.max;
        }) + 2)
      ]).range([0, width]);
      y = d3.scale.ordinal().domain(d3.map(this.data, function(d) {
        return d.user.name;
      }).keys()).rangePoints([0, height], 1);
      xAxis = d3.svg.axis().scale(x).orient("bottom").tickFormat(d3.time.format('%b %e'));
      yAxis = d3.svg.axis().scale(y).orient("left").ticks(10);
      this.svg.append("g").attr("class", "x axis").attr("transform", "translate(0," + height + ")").call(xAxis);
      this.svg.append("g").attr("class", "y axis").call(yAxis).append("text").attr("transform", "rotate(-90)").attr("y", 6).attr("dy", ".71em").style("text-anchor", "end").text("Developers");
      this.drawBar(x, y, startDate);
      this.drawFrontWhisker(x, y, startDate);
      this.drawBackWhisker(x, y, startDate);
      return this.svg.selectAll(".median").data(this.data.filter(function(d) {
        return d.stats.median !== d.stats.quartile1 && d.stats.median !== d.stats.quartile3;
      })).enter().append("line").attr("class", "median").attr("x1", (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(x, startDate, d.stats.median);
        };
      })(this)).attr("x2", (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(x, startDate, d.stats.median);
        };
      })(this)).attr("y1", function(d) {
        return y(d.user.name) - 10;
      }).attr("y2", function(d) {
        return y(d.user.name) + 10;
      });
    };

    UserScheduleGraph.prototype.drawBar = function(xscale, yscale, startDate) {
      var initialXEnd, initialXStart, xend, xstart;
      initialXStart = (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(xscale, startDate, d.stats.quartile1);
        };
      })(this);
      initialXEnd = (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(xscale, startDate, d.stats.quartile3);
        };
      })(this);
      xstart = function(d) {
        if (d.stats.quartile1 === d.stats.median && d.stats.quartile3 === d.stats.median) {
          return initialXStart(d) - 3;
        } else {
          return initialXStart(d);
        }
      };
      xend = function(d) {
        if (d.stats.quartile1 === d.stats.median && d.stats.quartile3 === d.stats.median) {
          return initialXEnd(d) + 3;
        } else {
          return initialXEnd(d);
        }
      };
      return this.svg.selectAll(".bar").data(this.data).enter().append("rect").attr("class", "bar").attr("x", function(d) {
        return xstart(d);
      }).attr("height", 20).attr("y", function(d) {
        return yscale(d.user.name) - 10;
      }).attr("width", (function(_this) {
        return function(d) {
          return xend(d) - xstart(d);
        };
      })(this));
    };

    UserScheduleGraph.prototype.drawFrontWhisker = function(xscale, yscale, startDate) {
      var conditionalLineStart, frontWhisker, lineEnd, lineStart, x;
      frontWhisker = this.svg.selectAll(".front-whisker").data(this.data).enter();
      lineStart = function(d) {
        return d.stats.min;
      };
      lineEnd = function(d) {
        return d.stats.quartile1;
      };
      x = (function(_this) {
        return function(d, func) {
          return _this.getCoordinateFromDate(xscale, startDate, func(d));
        };
      })(this);
      conditionalLineStart = function(d) {
        if (lineStart(d) === lineEnd(d)) {
          return x(d, lineStart) - 6;
        } else {
          return x(d, lineStart);
        }
      };
      frontWhisker.append("line").attr("class", "whisker").attr("x1", (function(_this) {
        return function(d) {
          return conditionalLineStart(d);
        };
      })(this)).attr("x2", (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(xscale, startDate, lineEnd(d));
        };
      })(this)).attr("y1", function(d) {
        return yscale(d.user.name);
      }).attr("y2", function(d) {
        return yscale(d.user.name);
      });
      return frontWhisker.append("line").attr("class", "whisker").attr("x1", (function(_this) {
        return function(d) {
          return conditionalLineStart(d);
        };
      })(this)).attr("x2", (function(_this) {
        return function(d) {
          return conditionalLineStart(d);
        };
      })(this)).attr("y1", function(d) {
        return yscale(d.user.name) - 10;
      }).attr("y2", function(d) {
        return yscale(d.user.name) + 10;
      });
    };

    UserScheduleGraph.prototype.drawBackWhisker = function(xscale, yscale, startDate) {
      var backWhisker, conditionalLineEnd, lineEnd, lineStart, x;
      backWhisker = this.svg.selectAll(".back-whisker").data(this.data).enter();
      lineStart = function(d) {
        return d.stats.quartile3;
      };
      lineEnd = function(d) {
        return d.stats.max;
      };
      x = (function(_this) {
        return function(d, func) {
          return _this.getCoordinateFromDate(xscale, startDate, func(d));
        };
      })(this);
      conditionalLineEnd = function(d) {
        if (lineStart(d) === lineEnd(d)) {
          return x(d, lineEnd) + 6;
        } else {
          return x(d, lineEnd);
        }
      };
      backWhisker.append("line").attr("class", "whisker").attr("x1", (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(xscale, startDate, lineStart(d));
        };
      })(this)).attr("x2", (function(_this) {
        return function(d) {
          return conditionalLineEnd(d);
        };
      })(this)).attr("y1", function(d) {
        return yscale(d.user.name);
      }).attr("y2", function(d) {
        return yscale(d.user.name);
      });
      return backWhisker.append("line").attr("class", "whisker").attr("x1", (function(_this) {
        return function(d) {
          return conditionalLineEnd(d);
        };
      })(this)).attr("x2", (function(_this) {
        return function(d) {
          return conditionalLineEnd(d);
        };
      })(this)).attr("y1", function(d) {
        return yscale(d.user.name) - 10;
      }).attr("y2", function(d) {
        return yscale(d.user.name) + 10;
      });
    };

    UserScheduleGraph.prototype.getCoordinateFromDate = function(scale, startDate, days) {
      return scale(d3.time.day.offset(startDate, days));
    };

    return UserScheduleGraph;

  })();

}).call(this);

//# sourceMappingURL=user-schedule.js.map
