<template>
<div>

  <!-- <div class="buscar-caja"> 
        <input type="text" name="" class="buscar-txt" placeholder="Search ....."/> 
        <a class="buscar-btn"> <i class="fa fa-search"></i> </a> 
        
    </div> 
    <div class="wrap" style="text-align: center; color: #fff;">
        <a href="http://opensnippets.com" target: "_blank" class="btn btn-primary">Download free bootstrap forms</a>
    </div> -->
  
  <form class="active-cyan-3 active-cyan-4 mb-4" v-on:submit.prevent="getFoods">
    <i class="fas fa-search"></i><input id="searchbar" class="form-control" v-on:change="getFoods" type="text" v-model="search" placeholder="Search.."/>
    <button class="btn btn-outline-info" type="submit">Submit</button>
 
  </form>
  <div>
    <form  v-for="food in meals" :key="food.fdcid" v-on:submit.prevent="saveFood(food)">
      <br>
      <h5>{{food.foodName}}</h5>
      <h6>Calories: {{food.foodCalories}}</h6>
      <select class="btn btn-outline-info" v-model="food.mealType">
        <span>Select meal type:</span>
        <option selected disabled value="">Please select one</option>
        <option>Breakfast</option>
        <option>Lunch</option>
        <option>Dinner</option>
        <option>Snack</option>
      </select>
      <select class="btn btn-outline-info" v-model="food.servings">
        <span>Select meal type:</span>
        <option selected disabled value="">Please select one</option>
        
        <option>1</option>
        
        <option>2</option>
        
        <option>3</option>
        
        <option>4</option>
        
        <option>5</option>
      </select>
      <input class="btn btn-outline-info" type="date" min="1900-01-01" v-model="food.consumptionDate">
      <!-- <input type="time" v-model="food.consumptionTime"> -->
      <button class="btn btn-outline-info" type="submit">Add Food</button>
    </form>
  </div>
  </div>
</template>

<script>       
import auth from "@/auth";
export default {
    name:"food-search",
    data(){
      return {
        meals: Array,
        meal: {
          FDCID: "",
          foodName: "",
          consumptionDate: "",
          servings: "",
          mealType: "",
          foodCalories: "",
          totalCalories: "",
        },
        search: ""
      }     
  },
  methods: {
    calculateTotalCalories(food){
      food.totalCalories = food.servings * food.foodCalories
    },
    getFoods(){ 
      fetch(`https://localhost:44392/api/Meal/foodSearch/${this.search}`,{
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
        Authorization: "Bearer " + auth.getToken()
      }
    })
      .then(response => {
        return response.json();
      })
      .then (meals => {
        this.meals = null;
        this.meals = meals;
      })
      .catch(err => console.error(err));
    },
    saveFood(food) {
      this.calculateTotalCalories(food);
      fetch(`${process.env.VUE_APP_REMOTE_API_MEAL}/AddMeal`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + auth.getToken()
        },
        body: JSON.stringify(food)
      })
       
        .then(err => console.error(err));
    }

  }
  
}

</script>

<style>
#foodSearchCard{
  height:150px;
  overflow-y: scroll;
}

#searchbar {
  border-color:#17a2b8;
}

.active-cyan-2 input[type=text]:focus:not([readonly]) {
  border-bottom: 1px solid #4dd0e1;
  box-shadow: 0 1px 0 0 #4dd0e1;
}
.active-cyan input[type=text] {
  border-bottom: 1px solid #4dd0e1;
  box-shadow: 0 1px 0 0 #4dd0e1;
}
.active-cyan .fa, .active-cyan-2 .fa {
  color: #4dd0e1;
}




/* .buscar-caja { 
  position: absolute; 
  top: 50%; left: 50%; 
  transform: translate(-50%, -50%); 
  background: #fff; 
  border-radius: 40px; 
  padding: 10px; 
} 
.buscar-caja:hover > .buscar-txt 
{
  width: 240px; 
  padding: 0 6px; 
} 
.buscar-caja:hover > .buscar-btn {
  background: white; 
  color: black; 
} 

.buscar-btn { 
  
  float: right; 
  width: 40px; 
  height: 40px; 
  border-radius: 50%; 
  
  display: flex; 
  justify-content: center; 
  align-items: center; 
  transition: 0.4s; 
  color: white; 
  cursor: pointer; 
} 
.buscar-btn > i 
{ 
  font-size: 18px; 
} 
.buscar-txt { 
  border: none; 
  background: none; 
  outline: none; 
  float: left; 
  padding: 0; 
  color: #333; 
  font-size: 16px; 
  transition: 0.4s; 
  line-height: 40px; 
  width: 0px; 
  font-weight: bold; 
}

.btn-primary{
    background: #fff;
    color: #CB356B;
    border: none;
} */


</style>