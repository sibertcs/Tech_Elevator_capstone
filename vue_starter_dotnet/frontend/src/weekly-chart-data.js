export const weeklyCalorieData = {
    type: 'line',
    data: {
      labels: [],
      datasets: [
        { // one line graph
          label: 'Calorie Intake',
          data: [],
          backgroundColor: [
            '#de7119'
          ],
          borderColor: [
            '#de7119'
          ],
          borderWidth: 3
        },
      ]
    },
    
    options: {
      responsive: true,
      lineTension: 1,
      scales: {
        yAxes: [{
          ticks: {
            beginAtZero: true,
            padding: 25,
          }
        }]
      }
    }
  }
  
  export default weeklyCalorieData;