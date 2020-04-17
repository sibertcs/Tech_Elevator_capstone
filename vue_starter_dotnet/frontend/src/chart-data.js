export const dailyCalorieData = {
    type: 'doughnut',
    data: {
      labels: ['Breakfast', 'Lunch', 'Dinner', 'Snack'],
      datasets: [
        { // one line graph
          label: 'Calories Consumed',
          data: [],
          backgroundColor: [
            '#17a2b8',
            '#116979',
            '#dee3e2',
            '#de7119'
           
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
/*       scales: {
        yAxes: [{
          ticks: {
            beginAtZero: true,
            padding: 25,
          }
        }] 
      }*/
    }
  }
  
  export default dailyCalorieData;

  