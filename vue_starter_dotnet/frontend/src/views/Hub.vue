<template>
  <header>
    <h1>Welcome {{user.sub}}!</h1>
    
      <ul class="nav">
        <li><router-link to='/profile'>Edit Profile</router-link></li>
        
      </ul>
    </header>
</template>

<script>
import auth from '../auth';

export default {
    name:"hub",
    data () {
      return {
        user: this.getUser()
      }      
    },
  methods: {
    getUser(){
        return auth.getUser();
      }
  }
}

</script>

<style>

</style>