<template>
  <div>
    <div class="form">
      <div class="form-input">
        <span class="label">Birthday:</span>
        <input required type="date" v-model="user.birthDate" />
      </div>
      <div class="form-input">
        <span class="label">Height(inches):</span>
        <input required type="number" min="24" max="96" v-model="user.height" />
      </div>
      <div class="form-input">
        <span class="label">Current Weight:</span>
        <input required type="number" min="1" max="1500" v-model="user.currentWeight" />
      </div>
      <div class="form-input">
        <span class="label">Goal Weight:</span>
        <input required type="number" min="1" max="1500" v-model="user.goalWeight" />
      </div>
      <div class="form-input">
        <span class="label">Picture location:</span>
        <input type="text" maxlength="200" v-model="user.profilePicture" />
      </div>
      <button v-on:click.prevent="addProfile" type="submit">Save Profile</button>
    </div>
  </div>
</template>

<script>
export default {
    name:"edit-profile",
    props: ['user_information'],
    data() {
        return {
            user: {
                birthdate: "",
                height: "",
                currentWeight: "",
                goalWeight: "",
                profilePicture: "",

            }
        }
    },
    created(){
        this.user.birthdate = this.user_information.birthdate;
        this.user.height = this.user_information.height;
        this.user.currentWeight = this.user_information.currentWeight;
        this.user.goalWeight = this.user_information.goalWeight;
        this.user.profilePicture = this.user_information.profilePicture;
    }
    
}
</script>

<style>

</style>