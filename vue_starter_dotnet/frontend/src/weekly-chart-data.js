export const weeklyCalorieData = {
    type: 'line',
    data: {
      labels: [],
      datasets: [
        { // one line graph
          label: 'Calories Consumed',
          data: [],
          backgroundColor: [
            '#119CFF'
          ],
          borderColor: [
            '#0B0B61'
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