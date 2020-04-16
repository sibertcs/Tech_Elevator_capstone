export const weeklyCalorieData = {
    type: 'line',
    data: {
      labels: [],
      datasets: [
        { // one line graph
          label: 'Calories Consumed',
          data: [],
          backgroundColor: [
            '#AC58FA', 
            '#AC58FA',
            '#AC58FA',
            '#AC58FA',
            '#AC58FA',
            '#AC58FA',
            '#AC58FA',
            '#AC58FA',
           
          ],
          borderColor: [
            '#AC58FA',
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
  
  export default weeklyCalorieData;