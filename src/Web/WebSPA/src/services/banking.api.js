import axios from 'axios'

const API_URL = 'https://localhost:5001'

const getBankingAccount = (userId) => {
  const url = `${API_URL}/api/accounts/user/` + userId
  return axios.get(url).then(response => response.data)
}
const getTransactionHistory = (bankingAccountId) => {
  const url = `${API_URL}/api/transactions?accountId=` + bankingAccountId
  return axios.get(url).then(response => response.data)
}

export {
  getBankingAccount,
  getTransactionHistory
}
