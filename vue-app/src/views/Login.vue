<template>
  <div>
    <form class="login" @submit.prevent="login">
      <h1>Sign in</h1>
      <label>Username Or EmailAddress</label>
      <input required v-model="usernameOrEmailAddress" type="text" placeholder="Name" />
      <label>Password</label>
      <input required v-model="password" type="password" placeholder="Password" />
      <hr />
      <button type="submit">Login</button>
    </form>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { Action } from 'vuex-class/lib';

@Component({
  name: 'Login',
})
export default class Login extends Vue {
  public usernameOrEmailAddress: string = '';
  public password: string = '';
  
  @Action('login', { namespace: 'AppModule' })
  public actionLogin!: (data: any) => Promise<any>;

  public login() {
    let usernameOrEmailAddress = this.usernameOrEmailAddress;
    let password = this.password;
    this.actionLogin({ usernameOrEmailAddress, password })
      .then(() => this.$router.push("/"))
      .catch(err => console.log(err));
  }
}
</script>

<style lang="scss" scoped>
</style>