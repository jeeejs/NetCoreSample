import React, { Component } from "react";
import { Link, withRouter } from "react-router-dom";

import LogoImg from "../../assets/logo.svg";
import { login } from "../../services/auth";

import { Form, Container } from "./styles";

class SignIn extends Component {
  state = {
    email: "",
    password: "",
    error: ""
  };

  handleSignIn = async e => {
    e.preventDefault();
    const { email, password } = this.state;
    const authenticated = await login(email, password);
    if (authenticated.success){
      this.props.history.push("/home");
    } else {
      this.setState({
        error: authenticated.error
      });
    }
  };

  render() {
    return (
      <Container>
        <Form onSubmit={this.handleSignIn}>
            <div>
                <img src={LogoImg} alt="Logo" />
            </div>
            {this.state.error && <p>{this.state.error}</p>}
            <div class="div-box">
                <div class="div-label-mobile">
                    <label class="label-mobile">E-mail</label>
                </div>
                <div class="div-input-mobile">
                    <input
                        class="input-mobile"
                        type="email"
                        onChange={e => this.setState({ email: e.target.value })}
                    />
                </div>
            </div>
            <div class="div-box">
                <div class="div-label-mobile">
                    <label class="label-mobile">Senha</label>
                </div>
                <div class="div-input-mobile">
                    <input
                        class="input-mobile"
                        type="password"
                        onChange={e => this.setState({ password: e.target.value })}
                    />
                </div>
            </div>
            <Link to="/">Esqueceu sua senha?</Link>
            <div class="div-button">
                <button type="submit">Entrar 
                    <svg class="arrow-svg" focusable="false" viewBox="0 0 24 24" aria-hidden="true" role="presentation">
                        <path fill="none" d="M0 0h24v24H0z">
                        </path>
                        <path d="M12 4l-1.41 1.41L16.17 11H4v2h12.17l-5.58 5.59L12 20l8-8z"></path>
                    </svg>
                </button>
            </div>
            <Link to="/">Sou novo aqui</Link>
        </Form>
      </Container>
    );
  }
}

export default withRouter(SignIn);