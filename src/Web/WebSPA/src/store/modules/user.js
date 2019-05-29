import { merge } from 'lodash'
import { getBankingAccount } from '@/services/banking.api'

const state = {
  bangking_account: {} // eslint-disable-line
}

const mutations = {
  // set user info
  SET_BANKING_ACCOUNT (state, account) {
    merge(state, account)
  }
}

const actions = {
  // init user info
  initBankingAccount ({ commit, dispatch, state }, payload) {
    return new Promise((resolve, reject) => {
      if (state.account) resolve(state.account)
      if (payload.accountid) {
        getBankingAccount(payload.accountid).then(data => { // eslint-disable-line
          if (data) {
            commit('SET_USER_INFO', data)
          }
          resolve(data)
        }).catch(err => { reject(err) })
      } else {
        resolve()
      }
    })
  }
}

const getters = {
  account (state) {
    return state.account
  }
}

export default {
  state,
  mutations,
  actions,
  getters
}
