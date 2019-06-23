import styled from "styled-components";

export const Container = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100vh;
`;

export const Form = styled.form`
  background: #f1f5f7;  
  display: flex;
  width: 302px;
  flex-direction: column;
  align-items: center;
  border: 1px;
  border-style: solid;
  border-color: silver;
  img {
    width: 100px;
    margin: 10px 0 40px;
  }
  p {
    color: #ff3333;
    margin-bottom: 15px;
    border: 1px solid #ff3333;
    padding: 10px;
    width: 100%;
    text-align: center;
  }
  button {
    min-width: 200px;
    min-height: 56px;
    width: 100%;
    background-color: rgb(51, 204, 204);
    color: rgb(255, 255, 255);
    border-width: 0px;
    border-style: initial;
    border-color: initial;
    border-image: initial;
    outline: none;
    padding:15px;
    margin-top: 5px;
    margin-bottom: 5px;
    display: flex;
    flex-direction: row;
    -webkit-box-pack: justify;
    justify-content: space-between;
    -webkit-box-align: center;
    align-items: center;    
    font-size: 16px;
    line-height: 1.5;    
  }
  a {
    text-underline-position: under;
    color: #96f;
    font-weight: 400 !important;
    font-size: 12px;
    text-decoration: none;
    margin-top: 10px;
    margin-bottom: 10px;
  }
`;