import React, { Component } from "react";
import { Link, withRouter } from "react-router-dom";

import LogoImg from "../../assets/logo.svg";
import { getUser } from "../../services/auth";

import { Form, Container } from "./styles";

class Home extends Component {
  state = {
    email: "",
    error: "",
    token: "",
    id: "",
    name: ""
  };

  handleHome = async e => {
    e.preventDefault();
    this.setState(await getUser());
  };

  render() {
    return (
      <Container>
        <Form onLoad={this.handleHome}>
            <div>
                <img src={LogoImg} alt="Logo" />
            </div>
            {this.state.error && <p>Erro: <br/>{this.state.error}  <br/><Link to="/">Entrar</Link></p>}
            {this.state.token && <p>Seu Bearer Token: <br/>{this.state.token}</p>}
            {this.state.id && <p>Codigo de usuário: <br/>{this.state.id}</p>}
            {this.state.name && <p>Nome: <br/>{this.state.name}</p>}
            {this.state.email && <p>Email: <br/>{this.state.email}</p>}
        </Form>
      </Container>
    );
  }
}

export default withRouter(Home);