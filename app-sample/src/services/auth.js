import api from "../services/api";

export const TOKEN_KEY = "@sample-app-token";
export const USER_ID = "@sample-app-user";
export const isAuthenticated = () => localStorage.getItem(TOKEN_KEY) !== null;
export const getToken = () => localStorage.getItem(TOKEN_KEY);
export const getUserId = () => localStorage.getItem(USER_ID);

export const login = async (email,password) => {
  setToken(null);
  setUserId(null);
  const result = {
    success: false,
    error: ""
  };

  if (!email || !password) {
    result.error = "Preencha e-mail e senha para continuar!";
  } else {
    try {
      const response = await api.post("/person/login", {email, password});
      if(response.data.authenticated === true){
        setToken(response.data.token);
        setUserId(response.data.id);
        result.success = true;
      } else {
        result.error = response.data.error;
      }
    } catch (err) {
      console.log(JSON.stringify(err));
      result.error = "Houve um problema com o login, verifique seus dados";
    }
  }

  return result;
};

export const getUser = async() => {
  try {
    const response = await api.get("/person/"+getUserId());
    response.data.token = getToken();
    return response.data;
  } catch (err) {
    console.log(JSON.stringify(err));
    return {
        error: "Usuário não autenticado !"
    };
  }    
};

export const setToken = token => {
  localStorage.setItem(TOKEN_KEY, token);
};

export const setUserId = userId => {
  localStorage.setItem(USER_ID, userId);
};

export const logout = () => {
  localStorage.removeItem(TOKEN_KEY);
};