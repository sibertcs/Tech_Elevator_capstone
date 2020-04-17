<template>
  <div>
    <div class="wrapper fadeInDown">
      <div id="loginContent">
        <!-- Tabs Titles -->

        <!-- Icon -->
        <div class="fadeIn first">
          <img
            src="data:image/jpeg;base64,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"
            style="margin-top: 20px; width: 40%; margin-bottom: 20px"
            id="icon"
            alt="User Icon"
          />
        </div>

        <!-- Login Form -->
        <form @submit.prevent="login">
          <input
            type="text"
            id="username"
            class="fadeIn second"
            name="login"
            v-model="user.username"
            required
            placeholder="Username"
          />
          <input
            type="password"
            id="password"
            class="fadeIn third"
            name="login"
            v-model="user.password"
            required
            placeholder="Password"
          />

          <div
            class="alert alert-danger"
            role="alert"
            v-if="invalidCredentials"
          >Invalid username and password!</div>
          <div
            class="alert alert-success"
            role="alert"
            v-if="this.$route.query.registration"
          >Thank you for registering, please sign in.</div>
          <input style="background-color: teal" type="submit" class="fadeIn fourth" value="Log In" />
        </form>

        <!-- Remind Passowrd -->
        <div id="loginFooter">
          <router-link class="needaccount" :to="{ name: 'register' }">Need an account?</router-link>
        </div>
      </div>
    </div>
    <!-- <div id="login" class="text-center">
      <form class="form-signin" @submit.prevent="login">
        <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
        <div
          class="alert alert-danger"
          role="alert"
          v-if="invalidCredentials"
        >Invalid username and password!</div>
        <div
          class="alert alert-success"
          role="alert"
          v-if="this.$route.query.registration"
        >Thank you for registering, please sign in.</div>
        <label for="username" class="sr-only">Username</label>
        <input
          type="text"
          id="username"
          class="form-control"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus
        />
        <label for="password" class="sr-only">Password</label>
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required
        />
        <router-link class="needaccount" :to="{ name: 'register' }">Need an account?</router-link>
        <button
          class="btn btn-outline-info"
          style="background-color: #e3f1f1;"
          type="submit"
        >Sign in</button>
      </form>
    </div> -->
  </div>
</template>

<script>
import auth from "../auth";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/login`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.user)
      })
        .then(response => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .then(token => {
          if (token != undefined) {
            if (token.includes('"')) {
              token = token.replace(/"/g, "");
            }
            auth.saveToken(token);
            this.$emit("loggedInUser");
            this.$router.push("/home");
          }
        })
        .catch(err => console.error(err));
    }
  }
};
</script>

<style>
.text-center {
  justify-content: center;
  color: teal;
}

.needaccount {
  color: teal;
  font-size: larger;
}

.wrapper {
  display: flex;
  align-items: center;
  flex-direction: column;
  justify-content: center;
  width: 100%;
  min-height: 100%;
  padding: 20px;
}

#loginContent {
  -webkit-border-radius: 10px 10px 10px 10px;
  border-radius: 10px 10px 10px 10px;
  background: #fff;
  padding: 30px;
  width: 90%;
  max-width: 450px;
  position: relative;
  padding: 0px;
  margin-left: 85px;
  -webkit-box-shadow: 0 30px 60px 0 rgba(0, 0, 0, 0.3);
  box-shadow: 0 30px 60px 0 rgba(0, 0, 0, 0.3);
  text-align: center;
}

#loginFooter {
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
  background-color: teal;
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
  background-color: teal;
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
input[type="password"] {
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
input[type="password"]:focus {
  background-color: #fff;
  border-bottom: 2px solid teal;
}

input[type="text"]:placeholder,
input[type="password"]:placeholder {
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

</style>
