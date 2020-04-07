<template>
  <div>
    <form class="form-register" @submit.prevent="addProfile">
      <h1>Your Profile</h1>
      <div class="form">
        <div class="form-input">
          <span class="label">Birthday:</span>
          <input type="date" v-model="user.birthDate" />
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
        <button type="submit">Save Profile</button>
       <!--  v-bind:disabled="!isValidForm" -->
      </div>
    </form>
  </div>
</template>

<script>
import auth from '@/auth';

export default {
  name: "profile",
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
  methods: {
    addProfile() {
        fetch(`${process.env.VUE_APP_REMOTE_API_PROFILE}/AddProfile`, {
          method: "POST",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: 'Bearer ' + auth.getToken(),
          },
          body: JSON.stringify(this.user)
        })
          .then(response => {
            if (response.ok) {
              this.$router.push({
                path: "/profile",
                query: { registration: "success" }
              });
            }
          })
          .then(err => console.error(err));      
      }
  },

  computed: {
    isValidForm() {
      return (
        this.user.birthday != "" &&
        this.user.height != "" &&
        this.user.currentWeight != "" &&
        this.user.goalWeight != ""
      );
    }
  }
};
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