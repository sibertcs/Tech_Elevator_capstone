export const monthlyCalorieData = {
    type: 'line',
    data: {
      labels: [],
      datasets: [
        { // one line graph
          label: 'Calorie Intake',
          data: [],
          backgroundColor: [
            '#dee3e2'
          ],
          borderColor: [
            '#36495d',
            '#36495d',
            '#36495d',
            '#36495d',
            '#36495d',
            '#36495d',
            '#36495d',
            '#36495d',
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
  
  export default monthlyCalorieData;