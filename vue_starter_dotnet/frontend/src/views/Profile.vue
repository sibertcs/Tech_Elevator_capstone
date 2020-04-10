<template>
<div>
  <form >
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
      <button v-on:click.prevent="saveProfile" type="submit">Save Profile</button>
    </div>
  </form>
</div>
</template>

<script>
import auth from "@/auth";

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
      },
      userName: this.getUser(),
      isNewUser: false
    };
  },
  created() {
    fetch(`${process.env.VUE_APP_REMOTE_API_PROFILE}/GetProfile`, {
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
        }
      })
      .catch(err => console.error(err));
  },
  methods: {
    getUser() {
      return auth.getUser();
    },

    addProfile() {
      fetch(`${process.env.VUE_APP_REMOTE_API_PROFILE}/AddProfile`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + auth.getToken()
        },
        body: JSON.stringify(this.user)
      })
        .then(response => {
          if (response.ok) {
            alert("Profile Added");
            this.$router.push({
              path: "/hub",
              query: { registration: "success" }
            });
          }
        })
        .then(err => console.error(err));
    },

    editProfile() {
      fetch(`${process.env.VUE_APP_REMOTE_API_PROFILE}/EditProfile`, {
        method: "PUT",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + auth.getToken()
        },
        body: JSON.stringify(this.user)
      })
        .then(response => {
          if (response.ok) {
            alert("Profile Updated");
            this.isNewUser = false;
            this.$router.push({
              path: "/hub",
              query: { registration: "success" }
            });
          }
        })
        .then(err => console.error(err));
    },

    saveProfile() {
      this.isNewUser ? this.addProfile() : this.editProfile();
    }
  },

  computed: {
    isValidForm() {
      return (
        this.user.birthDate != "" &&
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