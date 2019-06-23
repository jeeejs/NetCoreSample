export const TOKEN_KEY = "@sample-app-token";
export const USER_ID = "@sample-app-user";
export const isAuthenticated = () => localStorage.getItem(TOKEN_KEY) !== null;
export const getToken = () => localStorage.getItem(TOKEN_KEY);
export const getUser = () => localStorage.getItem(USER_ID);

export const login = token => {
  localStorage.setItem(TOKEN_KEY, token);
};

export const setUser = userId => {
  localStorage.setItem(USER_ID, userId);
};

export const logout = () => {
  localStorage.removeItem(TOKEN_KEY);
};