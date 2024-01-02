
const ctx3 = document.getElementById('total');
const colorctx3 = ["#FFF2CC", "#FFD966", "#F4B183", "#DFA67B"]
new Chart(ctx3, {
    type: 'bar',
    data: {
        labels: ['First Quarter', 'Second Quarter', 'Third Quarter', 'Fourth Quarter'],
        datasets: [{
            label: 'Revenue',
            data: [5129, 5358, 2769, 7894],
            borderWidth: 1,
            backgroundColor: colorctx3
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});


const ctx2 = document.getElementById('order');
const colortx2 = ["#FD8A8A", "#F1F7B5", "#A8D1D1", "#9EA1D4"]
new Chart(ctx2, {
    type: 'bar',
    data: {
        labels: ['First Quarter', 'Second Quarter', 'Third Quarter', 'Fourth Quarter'],
        datasets: [{
            label: 'Order',
            data: [103, 259, 89, 448],
            borderWidth: 1,
            backgroundColor: colortx2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});
const ctx5 = document.getElementById('profit');
const colortx5 = ["#FFC93C", "#86E5FF", "#5BC0F8", "#0081C9"]
new Chart(ctx5, {
    type: 'bar',
    data: {
        labels: ['First Quarter', 'Second Quarter', 'Third Quarter', 'Fourth Quarter'],
        datasets: [{
            label: 'profit',
            data: [103, 259, 89, 448],
            borderWidth: 1,
            backgroundColor: colortx2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});
const ctx4 = document.getElementById('country');
const colortx4 = ["#554994", "#F675A8", "#F29393", "#FFCCB3"]
new Chart(ctx4, {
    type: 'bar',
    data: {
        labels: ['First Quarter', 'Second Quarter', 'Third Quarter', 'Fourth Quarter'],
        datasets: [{
            label: 'country',
            data: [103, 259, 89, 448],
            borderWidth: 1,
            backgroundColor: colortx2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});






