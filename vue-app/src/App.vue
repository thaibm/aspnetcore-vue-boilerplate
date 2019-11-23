<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Home</router-link>
      <router-link to="/about">About</router-link>
      <span v-if="isAuthenticated">
        <a @click="logout">Logout</a>
      </span>
      <span v-else>
        <router-link to="/login">Login</router-link>
      </span>
    </div>
    <router-view />
  </div>
</template>
<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { Action, Getter } from 'vuex-class'

@Component({
  name: 'App'
})
export default class App extends Vue {
  @Getter('isAuthenticated', { namespace: 'AppModule' })
  public isAuthenticated!: boolean;

  @Action('logout', { namespace: 'AppModule' })
  public actionLogout!: () => Promise<any>;

  public mounted() {
  }

  public logout() {
    this.actionLogout().then(() => {
      this.$router.push("/login");
    });
  }
}
</script>
<style lang="scss">
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
