import Vue from 'vue'

const state = {
  lang: 'en',
  langs: [{
    label: 'English',
    value: 'en'
  }],
  pageLimit: 20
}

const mutations = {
  UPDATE (state, config) {
    state.lang = config.lang || state.lang
    state.pageLimit = config.pageLimit || state.pageLimit
  },
  UPDATE_LANG (state, lang) {
    state.lang = lang || state.lang
  }
}

const actions = {
  changeLang ({ commit }, lang) {
    Vue.config.lang = lang
    commit('UPDATE_LANG', lang)
  },
  updateGlobalConfig ({ commit, state, dispatch }, config) {
    if (config.lang !== state.lang) {
      Vue.config.lang = config.lang
    }
    commit('UPDATE', config)
  }
}

const getters = {
  globalConfig (state) {
    return state
  }
}

export default {
  state,
  mutations,
  actions,
  getters
}
