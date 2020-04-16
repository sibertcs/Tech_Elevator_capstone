<template>
  <div>
    <div class="wrapper fadeInDown">
      <div id="formContent">
        <div class="fadeIn first">
          <img
            v-if="user.profilePicture == ''"
            height="150"
            width="150"
            :src="this.defaultProfilePicture"
          />
          <img v-if="user.profilePicture != ''" height="150" width="150" :src="user.profilePicture" />
        </div>
       
        <form class="form-register" v-on:submit.prevent="saveProfile">
          <h5 class="label">Display Name:</h5>
          <input
            type="text"
            id="displayName"
            class="fadeIn second"
            required
            minlength="1"
            maxlength="25"
            placeholder="Enter Display Name"
            v-model="user.displayName"
          />
          <h5 class="label">Birth Date:</h5>
          <input
            class="fadeIn third"
            id="birthDate"
            required
            type="date"
            min="1900-01-01"
            max="2020-04-10"
            v-model="user.birthDate"
          />
          <h5 class="label">Height (inches):</h5>
          <input
            class="fadeIn fourth"
            id="height"
            required
            type="number"
            min="24"
            max="96"
            v-model="user.height"
            placeholder="Enter Height"
          />
          <h5 class="label">Current Weight (pounds):</h5>
          <input
            class="fadeIn fifth"
            id="weight"
            required
            type="number"
            min="1"
            max="1500"
            v-model="user.currentWeight"
          />
          <h5 class="label">Goal Weight (pounds):</h5>
          <input
            class="fadeIn sixth"
            id="weight"
            required
            type="number"
            min="1"
            max="1500"
            v-model="user.goalWeight"
          />

          <h5 class="label">Picture location:</h5>
          <input
            class="fadeIn seventh"
            id="profilePicture"
            type="url"
            maxlength="200"
            v-model="user.profilePicture"
            placeholder="Enter picture URL"
          />

          <input
            class="fadeIn eighth"
            value="Save Profile"
            type="submit"
          />
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
      defaultProfilePicture:
        "https://www.politicspa.com/wp-content/uploads/2013/07/Silhouette-question-mark.jpeg"
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
          this.user.birthDate = "1900-01-01";
          this.user.height = "";
          this.user.goalWeight = "";
          this.user.currentWeight = "";
          this.user.profilePicture = "";
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
        this.user.displayName > "0" &&
        this.user.displayName <= "25"
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
.wrapper {
  display: flex;
  align-items: center;
  flex-direction: column;
  justify-content: center;
  width: 100%;
  min-height: 100%;
  padding: 20px;
}

#formContent {
  -webkit-border-radius: 10px 10px 10px 10px;
  border-radius: 10px 10px 10px 10px;
  background: #fff;
  padding: 30px;
  width: 90%;
  max-width: 450px;
  position: relative;
  padding: 0px;
  -webkit-box-shadow: 0 30px 60px 0 rgba(0, 0, 0, 0.3);
  box-shadow: 0 30px 60px 0 rgba(0, 0, 0, 0.3);
  text-align: center;
}

#formFooter {
  background-color: #f6f6f6;
  border-top: 1px solid #dce8f1;
  padding: 25px;
  text-align: center;
  -webkit-border-radius: 0 0 10px 10px;
  border-radius: 0 0 10px 10px;
}

/* TABS */

h2.inactive {
  color: #cccccc;
}

h2.active {
  color: #0d0d0d;
  border-bottom: 2px solid #5fbae9;
}

/* FORM TYPOGRAPHY*/

input[type="button"],
input[type="submit"],
input[type="reset"] {
  background-color: #56baed;
  border: none;
  color: white;
  padding: 15px 80px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  text-transform: uppercase;
  font-size: 13px;
  -webkit-box-shadow: 0 10px 30px 0 rgba(95, 186, 233, 0.4);
  box-shadow: 0 10px 30px 0 rgba(95, 186, 233, 0.4);
  -webkit-border-radius: 5px 5px 5px 5px;
  border-radius: 5px 5px 5px 5px;
  margin: 5px 20px 40px 20px;
  -webkit-transition: all 0.3s ease-in-out;
  -moz-transition: all 0.3s ease-in-out;
  -ms-transition: all 0.3s ease-in-out;
  -o-transition: all 0.3s ease-in-out;
  transition: all 0.3s ease-in-out;
}

input[type="button"]:hover,
input[type="submit"]:hover,
input[type="reset"]:hover {
  background-color: #39ace7;
}

input[type="button"]:active,
input[type="submit"]:active,
input[type="reset"]:active {
  -moz-transform: scale(0.95);
  -webkit-transform: scale(0.95);
  -o-transform: scale(0.95);
  -ms-transform: scale(0.95);
  transform: scale(0.95);
}

input[type="text"],
input[type="password"],
input[type="number"],
input[type="date"],
input[type="url"] {
  background-color: #f6f6f6;
  border: none;
  color: #0d0d0d;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 5px;
  width: 85%;
  border: 2px solid #f6f6f6;
  -webkit-transition: all 0.5s ease-in-out;
  -moz-transition: all 0.5s ease-in-out;
  -ms-transition: all 0.5s ease-in-out;
  -o-transition: all 0.5s ease-in-out;
  transition: all 0.5s ease-in-out;
  -webkit-border-radius: 5px 5px 5px 5px;
  border-radius: 5px 5px 5px 5px;
}

input[type="text"]:focus,
input[type="password"]:focus,
input[type="number"]:focus,
input[type="date"]:focus,
input[type="url"]:focus {
  background-color: #fff;
  border-bottom: 2px solid #5fbae9;
}

input[type="text"]:placeholder,
input[type="password"]:placeholder,
input[type="number"]:placeholder,
input[type="date"]:placeholder,
input[type="url"]:placeholder {
  color: #cccccc;
}

/* ANIMATIONS */

/* Simple CSS3 Fade-in-down Animation */
.fadeInDown {
  -webkit-animation-name: fadeInDown;
  animation-name: fadeInDown;
  -webkit-animation-duration: 1s;
  animation-duration: 1s;
  -webkit-animation-fill-mode: both;
  animation-fill-mode: both;
}

@-webkit-keyframes fadeInDown {
  0% {
    opacity: 0;
    -webkit-transform: translate3d(0, -100%, 0);
    transform: translate3d(0, -100%, 0);
  }
  100% {
    opacity: 1;
    -webkit-transform: none;
    transform: none;
  }
}

@keyframes fadeInDown {
  0% {
    opacity: 0;
    -webkit-transform: translate3d(0, -100%, 0);
    transform: translate3d(0, -100%, 0);
  }
  100% {
    opacity: 1;
    -webkit-transform: none;
    transform: none;
  }
}

/* Simple CSS3 Fade-in Animation */
@-webkit-keyframes fadeIn {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
@-moz-keyframes fadeIn {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
@keyframes fadeIn {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}

.fadeIn {
  opacity: 0;
  -webkit-animation: fadeIn ease-in 1;
  -moz-animation: fadeIn ease-in 1;
  animation: fadeIn ease-in 1;

  -webkit-animation-fill-mode: forwards;
  -moz-animation-fill-mode: forwards;
  animation-fill-mode: forwards;

  -webkit-animation-duration: 1s;
  -moz-animation-duration: 1s;
  animation-duration: 1s;
}

.fadeIn.first {
  -webkit-animation-delay: 0.4s;
  -moz-animation-delay: 0.4s;
  animation-delay: 0.4s;
}

.fadeIn.second {
  -webkit-animation-delay: 0.6s;
  -moz-animation-delay: 0.6s;
  animation-delay: 0.6s;
}

.fadeIn.third {
  -webkit-animation-delay: 0.8s;
  -moz-animation-delay: 0.8s;
  animation-delay: 0.8s;
}

.fadeIn.fourth {
  -webkit-animation-delay: 1s;
  -moz-animation-delay: 1s;
  animation-delay: 1s;
}

.fadeIn.fifth {
  -webkit-animation-delay: 1.2s;
  -moz-animation-delay: 1.2s;
  animation-delay: 1.2s
}
.fadeIn.sixth {
  -webkit-animation-delay: 1.4s;
  -moz-animation-delay: 1.4s;
  animation-delay: 1.4s
}
.fadeIn.seventh {
  -webkit-animation-delay: 1.6s;
  -moz-animation-delay: 1.6s;
  animation-delay: 1.6s
}
.fadeIn.eighth {
  -webkit-animation-delay: 1.8s;
  -moz-animation-delay: 1.8s;
  animation-delay: 1.8s
}

/* Simple CSS3 Fade-in Animation */
.underlineHover:after {
  display: block;
  left: 0;
  bottom: -10px;
  width: 0;
  height: 2px;
  background-color: #56baed;
  content: "";
  transition: width 0.2s;
}

.underlineHover:hover {
  color: #0d0d0d;
}

.underlineHover:hover:after {
  width: 100%;
}

/* OTHERS */

*:focus {
  outline: none;
}

#icon {
  width: 60%;
}
</style>

