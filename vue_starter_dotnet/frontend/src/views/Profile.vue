<template>
  <div>
    <form v-if="!isNewUser" class="form-register" @submit.prevent="addProfile">
      <h1>Create Your Profile</h1>
      <create-profile v-on:addProfile="addProfile"></create-profile>
           
    </form>
    <form v-bind:user='user_information' class="form-register" @submit.prevent="editProfile">
      <h1>Edit Your Profile</h1>
      <edit-profile v-on:addProfile="editProfile"></edit-profile>
    </form>
  </div>
</template>

<script>
import auth from '@/auth';
import CreateProfile from '@/components/CreateProfile.vue'
import EditProfile from '@/components/EditProfile.vue'

export default {
  name: "profile",
  components:{
    CreateProfile,
    EditProfile
  },
  
  data() {
    return {
      user: {
        birthDate: "",
        height: "",
        currentWeight: "",
        goalWeight: "",
        profilePicture: ""
      },
      isNewUser: true
    };
  },
  methods: {
    addProfile(data) {
        fetch(`${process.env.VUE_APP_REMOTE_API_PROFILE}/AddProfile`, {
          method: "POST",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: 'Bearer ' + auth.getToken(),
          },
          body: JSON.stringify(data)
        })
          .then(response => {
            if (response.ok) {
              alert("Profile Added");
              this.birthDate = data.birthDate;
              this.height = data.height;
              this.currentWeight = data.currentWeight;
              this.goalWeight = data.goalWeight;
              this.profilePicture = data.profilePicture;
              this.isNewUser = false
              this.$router.push({
                path: "/hub",
                query: { registration: "success" }
              });
            }
          })
          .then(err => console.error(err));      
      }
  },
    editProfile(data) {
        fetch(`${process.env.VUE_APP_REMOTE_API_PROFILE}/EditProfile`, {
          method: "PUT",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: 'Bearer ' + auth.getToken(),
          },
          body: JSON.stringify(data)
        })
          .then(response => {
            if (response.ok) {
              alert("Profile Updated");
              this.isNewUser = false
              this.$router.push({
                path: "/hub",
                query: { registration: "success" }
              });
            }
          })
          .then(err => console.error(err));      
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