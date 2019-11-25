import Vue from 'vue'
import Vuex, { StoreOptions } from 'vuex';
import { AppModule } from './modules/app';

Vue.use(Vuex)
export interface RootState {
  version: string;
}

const store: StoreOptions<RootState> = {
  state: {
    version: '1.0.0'
  },
  modules: {
    AppModule
  }
};

export default new Vuex.Store<RootState>(store);
