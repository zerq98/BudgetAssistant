$(function () {
    var chart = document.getElementById("chart").getContext("2d");
    var data = {
        labels: XLabels,
        datasets: [{
            label: "Expenses",
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 0, 0)',
                'rgba(0, 255, 0)',
                'rgba(0, 0, 255)',
                'rgba(192, 192, 192)',
                'rgba(255, 255, 0)',
                'rgba(255, 0, 255)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)',
                'rgba(255, 0, 0)',
                'rgba(0, 255, 0)',
                'rgba(0, 0, 255)',
                'rgba(192, 192, 192)',
                'rgba(255, 255, 0)',
                'rgba(255, 0, 255)'
            ],
            borderWidth: 1,
            data: YValues
        }]
    };

    var options = {
        maintainAspectRatio: false,
        scales: {
            yAxes: [{
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                gridLines: {
                    display: true,
                    color: "rgba(255,99,164,0.2)"
                }
            }],
            xAxes: [{
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                gridLines: {
                    display: false
                }
            }]
        }
    };

    var myChart = new Chart(chart, {
        options: options,
        data: data,
        type: 'pie'
    });
});