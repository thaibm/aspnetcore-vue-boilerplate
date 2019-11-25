<template>
    <div class="login-page">
        <b-form @submit.prevent="login" class="form-login">
            <div class="logo-vue">
                <img alt="Vue logo" src="../assets/logo.png" />
            </div>
            <h1 class="h3 mb-3 font-weight-normal">Please login</h1>
            <b-form-group
                id="username-group"
                label="Username Or EmailAddress:"
                label-for="username-email"
                description="We'll never share your email with anyone else."
            >
                <b-form-input
                    id="username-email"
                    v-model="usernameOrEmailAddress"
                    type="text"
                    required
                    placeholder="Enter your Username Or EmailAddress"
                ></b-form-input>
            </b-form-group>

            <b-form-group id="password-group" label="Password:" label-for="password">
                <b-form-input
                    id="password"
                    v-model="password"
                    type="password"
                    required
                    placeholder="Enter your Password"
                ></b-form-input>
            </b-form-group>

            <b-button type="submit" variant="primary" block>Login</b-button>
            <p class="mt-5 mb-3 text-muted text-center">© 2017-2019</p>
        </b-form>
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
.login-page {
  display: flex;
  align-items: center;
  height: 100vh;
}

.form-login {
    width: 100%;
    max-width: 330px;
    padding: 1rem;
    margin: auto;

    .logo-vue {
      text-align: center;
      padding-bottom: 2rem;

      img {
        max-width: 7.5rem;
      }
    }
}
</style>