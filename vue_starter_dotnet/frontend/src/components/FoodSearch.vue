<template>
<div>
  <h1>FoodSearch</h1>
  <form v-on:submit.prevent="getFoods">
    <input type="text" v-model="search" placeholder="Search for foods.."/>
    <button type="submit">Search</button>
  </form>
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
          totalCalories: "",
        },
        search: ""
        
        
      }
      
  },
  methods: {
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
      .then(user => {
        this.user = user;
        this.user.birthDate = user.birthDate.substring(0, 10);
        
        if (this.user.height === 0) {
          this.isNewUser = true;
          this.user.birthDate = "1900-01-01"
          this.user.height = "";
          this.user.goalWeight = "";
          this.user.currentWeight = "";
          this.user.profilePicture = ""
         
        }
      })
      .catch(err => console.error(err));
    }
  }

}
</script>

<style>

</style>