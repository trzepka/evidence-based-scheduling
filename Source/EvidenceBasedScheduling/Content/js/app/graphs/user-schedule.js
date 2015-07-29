(function() {
  App.UserScheduleGraph = (function() {
    function UserScheduleGraph(parentTagId, data, showUnassignedTasks) {
      this.parentTagId = parentTagId;
      this.data = data;
      this.showUnassignedTasks = showUnassignedTasks;
    }

    UserScheduleGraph.prototype.draw = function() {
      var func;
      this.init();
      this.doDraw();
      func = (function(_this) {
        return function() {
          return _this.doDraw();
        };
      })(this);
      return setInterval(func, 1000);
    };

    UserScheduleGraph.prototype.init = function() {
      var margin, maxUserNameLength;
      margin = {
        top: 20,
        right: 20,
        bottom: 30,
        left: 60
      };
      maxUserNameLength = d3.max(this.data, function(d) {
        return d.user.name.length;
      }) * 6;
      margin.left = maxUserNameLength + 5;
      this.startDate = new Date();
      this.width = 960 - margin.left - margin.right;
      this.height = 500 - margin.top - margin.bottom;
      this.svg = d3.select('#' + this.parentTagId).append("svg").attr("width", this.width + margin.left + margin.right).attr("height", this.height + margin.top + margin.bottom).append("g").attr("transform", "translate(" + margin.left + "," + margin.top + ")");
      return this.initAxes();
    };

    UserScheduleGraph.prototype.initAxes = function() {
      var x, y;
      x = d3.time.scale().domain([
        this.startDate, d3.time.day.offset(this.startDate, d3.max(this.data, function(d) {
          return d.stats.max;
        }) + 2)
      ]).range([0, this.width]);
      y = d3.scale.ordinal().domain(d3.map(this.data, function(d) {
        return d.user.name;
      }).keys()).rangePoints([0, this.height], 1);
      this.xAxis = d3.svg.axis().scale(x).orient("bottom").tickFormat(d3.time.format('%b %e'));
      this.yAxis = d3.svg.axis().scale(y).orient("left").ticks(10);
      this.svg.append("g").attr("class", "axis x.axis").attr("transform", "translate(0," + this.height + ")").call(this.xAxis);
      return this.svg.append("g").attr("class", "y axis").call(this.yAxis).append("text").attr("transform", "rotate(-90)").attr("y", 6).attr("dy", ".71em").style("text-anchor", "end").text("Developers");
    };

    UserScheduleGraph.prototype.doDraw = function() {
      var format, x, y;
      format = d3.time.format("%Y-%m-%d");
      x = d3.time.scale().domain([
        this.startDate, d3.time.day.offset(this.startDate, d3.max(this.data, function(d) {
          return d.stats.max;
        }) + 2)
      ]).range([0, this.width]);
      y = d3.scale.ordinal().domain(d3.map(this.data, function(d) {
        return d.user.name;
      }).keys()).rangePoints([0, this.height], 1);
      this.svg.selectAll(".y.axis").call(this.yAxis);
      this.svg.selectAll(".x.axis").call(this.xAxis);
      this.drawBar(x, y, this.startDate);
      this.drawFrontWhisker(x, y, this.startDate);
      this.drawBackWhisker(x, y, this.startDate);
      return this.svg.selectAll(".median").data(this.data.filter(function(d) {
        return d.stats.median !== d.stats.quartile1 && d.stats.median !== d.stats.quartile3;
      })).enter().append("line").attr("class", "median").attr("x1", (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(x, _this.startDate, d.stats.median);
        };
      })(this)).attr("x2", (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(x, _this.startDate, d.stats.median);
        };
      })(this)).attr("y1", function(d) {
        return y(d.user.name) - 10;
      }).attr("y2", function(d) {
        return y(d.user.name) + 10;
      });
    };

    UserScheduleGraph.prototype.drawBar = function(xscale, yscale, startDate) {
      var bar, initialXEnd, initialXStart, xend, xstart;
      this.startDate = startDate;
      initialXStart = (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(xscale, _this.startDate, d.stats.quartile1);
        };
      })(this);
      initialXEnd = (function(_this) {
        return function(d) {
          return _this.getCoordinateFromDate(xscale, _this.startDate, d.stats.quartile3);
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
      bar = this.svg.selectAll(".bar").data(this.data.filter((function(_this) {
        return function(d) {
          return _this.showUnassignedTasks === true || (_this.showUnassignedTasks === false && d.user.name !== "Unassigned");
        };
      })(this)));
      bar.enter().append("rect").attr("class", "bar").attr("x", function(d) {
        return xstart(d);
      }).attr("height", 20).attr("y", function(d) {
        return yscale(d.user.name) - 10;
      }).attr("width", (function(_this) {
        return function(d) {
          return xend(d) - xstart(d);
        };
      })(this));
      return bar.exit().remove();
    };

    UserScheduleGraph.prototype.drawFrontWhisker = function(xscale, yscale, startDate) {
      var conditionalLineStart, frontWhisker, lineEnd, lineStart, x;
      this.startDate = startDate;
      frontWhisker = this.svg.selectAll(".front-whisker").data(this.data).enter();
      lineStart = function(d) {
        return d.stats.min;
      };
      lineEnd = function(d) {
        return d.stats.quartile1;
      };
      x = (function(_this) {
        return function(d, func) {
          return _this.getCoordinateFromDate(xscale, _this.startDate, func(d));
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
          return _this.getCoordinateFromDate(xscale, _this.startDate, lineEnd(d));
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
      this.startDate = startDate;
      backWhisker = this.svg.selectAll(".back-whisker").data(this.data).enter();
      lineStart = function(d) {
        return d.stats.quartile3;
      };
      lineEnd = function(d) {
        return d.stats.max;
      };
      x = (function(_this) {
        return function(d, func) {
          return _this.getCoordinateFromDate(xscale, _this.startDate, func(d));
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
          return _this.getCoordinateFromDate(xscale, _this.startDate, lineStart(d));
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
      this.startDate = startDate;
      return scale(d3.time.day.offset(this.startDate, days));
    };

    return UserScheduleGraph;

  })();

}).call(this);

//# sourceMappingURL=user-schedule.js.map
