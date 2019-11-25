<template>
    <div id="app">
        <b-navbar type="light" variant="light" v-if="isAuthenticated">
            <b-navbar-nav>
                <b-nav-item to="/">Home</b-nav-item>
                <b-nav-item to="/about">About</b-nav-item>
                <b-nav-item @click="logout" v-if="isAuthenticated">Logout</b-nav-item>
                <b-nav-item to="/login" v-else>Login</b-nav-item>
            </b-navbar-nav>
        </b-navbar>
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
</style>
