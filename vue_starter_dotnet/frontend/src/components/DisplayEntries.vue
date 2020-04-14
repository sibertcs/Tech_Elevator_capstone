<template>
  <div>
    <div v-for="food in meals" :key="food.mealID">
        <h5>{{food.foodName}}</h5>
        <h5>Servings: {{food.servings}}</h5>
        <h5>Calories: {{food.totalCalories}}</h5>
        <h5>Date: {{trimTime(food.consumptionDate)}}</h5>
        <button v-on:click="removeEntry(food.mealID)" >Remove Entry</button>
        <button v-if="isHidden" v-on:click="isHidden = false" >Edit Entry</button>
        <button v-if="!isHidden" v-on:click="isHidden = true" >Hide Form</button>
        <form v-if="!isHidden" v-on:submit.prevent="editEntry(food)">
            <select v-model="food.mealType">
                <span>Select meal type:</span>
                <option selected disabled value="">Please select one</option>
                <option>Breakfast</option>
                <option>Lunch</option>
                <option>Dinner</option>
                <option>Snack</option>
            </select>
            <select v-model="food.servings">
                <span>Select meal type:</span>
                <option selected disabled value="">Please select one</option>
                <option>0.5</option>
                <option>1</option>
                <option>1.5</option>
                <option>2</option>
                <option>2.5</option>
                <option>3</option>
                <option>3.5</option>
                <option>4</option>
                <option>4.5</option>
                <option>5</option>
            </select>
            <button type="submit" >Edit Entry</button>
        </form>
        <!-- <button type="submit" v-on:submit.prevent="isHidden == 'false'">Edit Entry</button>  -->
    </div>
    
    

  </div>
</template> 

<script>
import auth from "@/auth";

export default {
    name: 'display-entries',
    data(){
        return{
            meals: Array,
            isHidden: true
        }
    },
    methods: {
        trimTime (date){
            return date.substring(0, 10);
        },
        calculateTotalCalories(food){
            food.totalCalories = food.servings * food.foodCalories
        },    
        removeEntry(Id){
            fetch(`https://localhost:44392/api/Meal/RemoveEntry`, {
                method: "DELETE",
                headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
                Authorization: "Bearer " + auth.getToken()
                 },
                 body: JSON.stringify(Id)
            })
            .then(response => {
                if(response.ok){
                    alert("Entry successfully deleted");
                    const changeMealToOnlyId = this.meals.map(meal =>meal.mealID);
                    const index = changeMealToOnlyId.indexOf(Id);
                    
                    this.meals.splice(index,1);
                    /* this.$router.push({
                    path: "/home", */
                
                }
                
            })
            
            .catch(err => console.error(err));
        },
        editEntry(food) {
        this.calculateTotalCalories(food);
        fetch(`https://localhost:44392/api/Meal/EditEntry`, {
            method: "PUT",
            headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: "Bearer " + auth.getToken()
            },
            body: JSON.stringify(food)
            })
            .then(response => {
            if (response.ok) {
                alert("Entry Updated");
                this.$router.push({
                path: "/home",
                });
            }
            })
            .then(err => console.error(err));
        },
                
    },
    created() {
    fetch(`https://localhost:44392/api/Meal/DisplayEntries`, {
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
}
</script>

<style>
</style>