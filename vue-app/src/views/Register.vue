<template>
  <div>
    <h4>Register</h4>
    <form @submit.prevent="register">
      <label for="name">User Name</label>
      <div>
        <input id="name" type="text" v-model="userName" required autofocus />
      </div>
      <label for="email">E-Mail Address</label>
      <div>
        <input id="email" type="email" v-model="email" required />
      </div>
      <label for="password">Password</label>
      <div>
        <input id="password" type="password" v-model="password" required />
      </div>
      <label for="password-confirm">Confirm Password</label>
      <div>
        <input id="password-confirm" type="password" v-model="password_confirmation" required />
      </div>
      <div>
        <button type="submit">Register</button>
      </div>
    </form>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'

@Component({
    name: 'Register',
})
export default class Register extends Vue {
  public email: string = '';
  public password: string = '';
  public password_confirmation: string = '';
  public userName: string = '';

  public register() {
    let data = {
      userName: this.userName,
      email: this.email,
      password: this.password,
    };
    this.$store
      .dispatch("register", data)
      .then(() => this.$router.push("/"))
      .catch(err => console.log(err));

  }
}
</script>

<style lang="scss" scoped>
</style>