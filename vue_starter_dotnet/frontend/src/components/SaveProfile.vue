<template>
  <form>
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
  </form>
</template>

<script>
export default {
    name:'profile',
    components:{
        
        
    },
    data() {
     return {
      user: {
        birthDate: "",
        height: "",
        currentWeight: "",
        goalWeight: "",
        profilePicture: ""
      }
    };
    },
        methods: {}
}
</script>

<style>

</style>