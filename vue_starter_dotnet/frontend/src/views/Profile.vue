<template>
  <div>
    <h1>Your Profile</h1>
    <div class="form">
      <div class="form-input">
        <span class="label">Birthday:</span>
        <input type="date" v-model="user.birthday"/>
      </div>
      <div class="form-input">
        <span class="label">Height(inches):</span>
        <input type="number" min="24" max="96" v-model="user.height" />
      </div>
      <div class="form-input">
        <span class="label">Current Weight:</span>
        <input type="number" min="1" max="1500" v-model="user.currentWeight" />
      </div>
      <div class="form-input">
        <span class="label">Goal Weight:</span>
        <input type="number" min="1" max="1500" v-model="user.goalWeight" />
      </div>
    <button v-bind:disabled="!isValidForm" v-on:click="saveProfile">Save Profile</button>
    </div>
  </div>

</template>

<script>
export default {
    name:"profile",
    data(){
        return{
            user: {
                username: "",
                password: "",
                birthday: "",
                height: "",
                currentWeight: "",
                goalWeight: "",
                profilePicture: ""

            }         
        }
    },
    computed: {
        isValidForm() {
            return (
                this.user.birthday != "" &&
                this.user.height != "" &&
                this.user.currentWeight != "" &&
                this.user.goalWeight != ""
            )
        }
    }
    
}
</script>

<style>
.form {
  margin-top: 20px;
  width: 510px;
}
.form-input {
  padding: 10px;
}
</style>