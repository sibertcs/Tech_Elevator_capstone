<template>
  <div>
    <div class="profile-display">
      <img v-if="user.profilePicture == ''" height="150" width="150" :src= "this.defaultProfilePicture">
      <img v-if="user.profilePicture != ''" height="150" width="150" :src= "user.profilePicture">
      <br>
      <br>
      <div style="text-align: center;">
        <div style="display: inline-block; text-align: left;">
      <h4>Display Name: {{user.displayName}}</h4>
      <h4>Birthday:   {{user.birthDate}}</h4>
      <h4>Height:   {{user.height}}</h4>
      <h4>Current Weight:   {{user.currentWeight}}</h4>
      <h4>Goal Weight:  {{user.goalWeight}}</h4>
        </div>
      </div>
    </div>
    <br>
    <div class="edit-profile">
    <button class="btn btn-outline-info" style="background-color: #e3f1f1;" v-on:click="isHidden=false">Edit Profile</button>
    <div class="form-class">
    <form v-if="!isHidden" v-on:submit.prevent="saveProfile">
      <div class="form">
         <div class="form-input">
          <span class="label">Display Name:</span>
          <input required type="text" minLength="1" maxLength="25" placeholder="Enter display name" v-model="user.displayName" />
        </div>
        <div class="form-input">
          <span class="label">Birthday:</span>
          <input required type="date" min="1900-01-01" max="2020-04-10" v-model="user.birthDate" />
        </div>
        <div class="form-input">
          <span class="label">Height(inches):</span>
          <input
            class="form-control"
            required
            type="number"
            min="24"
            max="96"
            v-model="user.height"
            placeholder="Enter height"
          />
        </div>
        <div class="form-input">
          <span class="label">Current Weight:</span>
          <input
            class="form-control"
            required
            type="number"
            min="1"
            max="1500"
            v-model="user.currentWeight"
          />
        </div>
        <div class="form-input">
          <span class="label">Goal Weight:</span>
          <input
            class="form-control"
            required
            type="number"
            min="1"
            max="1500"
            v-model="user.goalWeight"
          />
        </div>
        <div class="form-input">
          <span class="label">Picture location:</span>
          <input class="form-control" type="url" maxlength="200" v-model="user.profilePicture" placeholder="Enter picture URL" />
        </div>
        <button type="submit">Save Profile</button>
      </div>
    </form>
    </div>
    </div>
  </div>
</template>

<script>
import auth from "@/auth";

export default {
  name: "profile",

  data() {
    return {
      user: {
        displayName: "",
        birthDate: "",
        height: "",
        currentWeight: "",
        goalWeight: "",
        profilePicture: ""
      },
      
      userName: this.getUser(),
      isNewUser: false,
      isHidden: true,
      formValidation: false,
      defaultProfilePicture: "https://www.politicspa.com/wp-content/uploads/2013/07/Silhouette-question-mark.jpeg"
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
          this.user.birthDate = "1900-01-01"
          this.user.height = "";
          this.user.goalWeight = "";
          this.user.currentWeight = "";
          this.user.profilePicture = ""
         
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
              path: "/home",
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
              path: "/login",
              query: { registration: "success" }
            });
          }
        })
        .then(err => console.error(err));
    },

    isFormValid() {
      if (
        this.user.birthDate >= "1900-01-01" &&
        this.user.birthDate <= "2020-04-04" &&
        this.user.height >= "24" &&
        this.user.height <= "96" &&
        this.user.currentWeight >= "1" &&
        this.user.currentWeight <= "1500" &&
        this.user.goalWeight >= "1" &&
        this.user.goalWeight <= "1500" &&
        this.user.displayName >"0" &&
        this.user.displayName <="25"
      ) {
        return true;
      } else {
        return false;
      }
    },
    saveProfile() {
      
      this.isNewUser ? this.addProfile() : this.editProfile();
      
    }
  },

  computed: {}
};
</script>

<style>

.profile-display{
color:teal;
/* text-justify: left; */
text-align: center;

}

.form-class {
  text-align: center;
}

.edit-profile {
  text-align: center;
}

.form {
  width: 300px;
  text-align: center;
  margin-top: 20px;  
}

.form-input {
  padding: 10px;
  text-justify: center;
  justify-items: center;
}

</style>