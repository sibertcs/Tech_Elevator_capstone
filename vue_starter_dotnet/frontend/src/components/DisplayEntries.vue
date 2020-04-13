<template>
  <div>
        <form v-for="food in meals" :key="food.mealID" v-on:submit.prevent="removeEntry(food.mealID)">
        <h5>{{food.foodName}}</h5>
        <button type="submit">Remove Entry</button>
        </form>
 
  </div>
</template>

<script>
import auth from "@/auth";

export default {
    name: 'display-entries',
    data(){
        return{
            meals: Array
        }
    },
    methods: {
        removeEntry(mealID){
            fetch(`https://localhost:44392/api/Meal/RemoveEntry`, {
                method: "DELETE",
                headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
                Authorization: "Bearer " + auth.getToken()
                 },
                 body: JSON.stringify(mealID)
            })
            .then(response => {
                if(response.ok){
                    alert("Entry successfully deleted");
                    this.$router.push({
                    path: "/home",
                });
                }
                
            })
            .then (meals => {
                this.meals = null;
                this.meals = meals;
                
            })
            .catch(err => console.error(err));
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