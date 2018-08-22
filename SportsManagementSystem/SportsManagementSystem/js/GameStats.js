/// <reference path="angular.js" />
/// <reference path="angular.min.js" />
/// <reference path="angular-chart.js" />
/// <reference path="angular-chart.min.js" />

BASE_URL = "http://localhost:57567/GameService.svc/";
var REPORT_BASE_URL = "http://localhost:57567/ReportService.svc/";
var app;
//Module  
(function () {
    app = angular.module("MyGameStats_App", ['chart.js']);
})();

//Config
app.config(['ChartJsProvider', function (ChartJsProvider) {
    // Configure all charts 
    ChartJsProvider.setOptions({
        chartColors: ["#455C73", "#9B59B6", "#BDC3C7", "#26B99A"],
        responsive: true,
        scales: { yAxes: [{ ticks: { min: 0, stepSize: 1 } }] }

    });
}]);


app.controller("cntrl_MyGameStats", function ($scope, MyGameStats) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = MyGameStats.get();
    $scope.games = [];
    promiseGet1.then(function (pl) {
        $scope.games = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

app.controller("pieCtrl_YellowCards", function ($scope, YellowCards) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = YellowCards.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_RedCards", function ($scope, RedCards) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = RedCards.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_GameFouls", function ($scope, GameFouls) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = GameFouls.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_GamePosition", function ($scope, GamePosition) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = GamePosition.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_CornerKick", function ($scope, CornerKick) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = CornerKick.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});
app.controller("pieCtrl_Goals", function ($scope, Goals) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = Goals.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});


//SERVICE================================================================
//Game Stats Service by lleague ID 
//L_ID
app.service("MyGameStats", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetAllGameStatByLeagueID/" + getUrlParameter('L_ID'));
    };
});

//Game Yellow Cards
app.service("YellowCards", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(REPORT_BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",YellowCards");
    };
});
//Game Red Cards
app.service("RedCards", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(REPORT_BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",RedCards");
    };
});
//Game Fouls
app.service("GameFouls", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(REPORT_BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",Fouls");
    };
});
//Game Position
app.service("GamePosition", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(REPORT_BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",Position");
    };
});
//Game Coner Kicks
app.service("CornerKick", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(REPORT_BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",CornerKicks");
    };
});
// Goals scored in a game
app.service("Goals", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(REPORT_BASE_URL + "gt_GameStats/" + getUrlParameter('G_ID') + ",GoalsScored");
    };
});


//helper functions=====================================================
function getUrlParameter(param, dummyPath) {
    var sPageURL = dummyPath || window.location.search.substring(1),
        sURLVariables = sPageURL.split(/[&||?]/),
        res;
    for (var i = 0; i < sURLVariables.length; i += 1) {
        var paramName = sURLVariables[i],
            sParameterName = (paramName || '').split('=');

        if (sParameterName[0] === param) {
            res = sParameterName[1];
        }
    }
    return res;
}
