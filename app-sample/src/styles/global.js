import { injectGlobal } from "styled-components";

import "font-awesome/css/font-awesome.css";

injectGlobal`
* {
  box-sizing: border-box;
  padding: 0;
  margin: 0;
  outline: 0;
}
body, html {
  background: white;
  font-family: 'Helvetica Neue', 'Helvetica', Arial, sans-serif;
  text-rendering: optimizeLegibility !important;
  -webkit-font-smoothing: antialiased !important;
  height: 100%;
  width: 100%;
}
input {
  -webkit-writing-mode: horizontal-tb !important;
  text-rendering: auto;
  color: white;
  letter-spacing: normal;
  word-spacing: normal;
  text-transform: none;
  text-indent: 0px;
  text-shadow: none;
  display: inline-block;
  text-align: start;
  -webkit-appearance: textfield;
  background-color: white;
  -webkit-rtl-ordering: logical;
  cursor: text;
  margin: 0em;
  font: 400 13.3333px Arial;
  padding: 1px 0px;
  border-width: 2px;
  border-style: inset;
  border-color: initial;
  border-image: initial;
}
.arrow-svg {
  fill: currentColor;
  width: 1em;
  height: 1em;
  display: inline-block;
  font-size: 24px;
  transition: fill 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
  user-select: none;
  flex-shrink: 0;
}
.div-label-mobile {
  display: -ms-flexbox;
  display: flex;
  -ms-flex-direction: row;
  flex-direction: row;
  -ms-flex-pack: justify;
  justify-content: space-between;
  -ms-flex-align: center;
  align-items: center;
  padding: 0px 0px 0;  
}
.label-mobile {
  font-size: 14px;
  font-weight: 400;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: normal;
  padding: 5px 0px 0px 24px;
  color: #859099;
}
.div-input-mobile {
  display: -ms-flexbox;
  display: flex;
  -ms-flex-direction: row;
  flex-direction: row;
  -ms-flex-pack: end;
  justify-content: flex-end;
  -ms-flex-align: end;
  align-items: flex-end;
  padding-right: 24px;
  padding-bottom: 13px;
  -ms-flex: 1 1;
  flex: 1 1;
}
.input-mobile {
  border: none;
  outline: none;
  padding: 5px 5px 16px 24px;
  font-size: 20px;
  font-weight: 400;
  font-style: normal;
  font-stretch: normal;
  line-height: 1.2;
  letter-spacing: normal;
  color: #4a5365;
  bottom: 0;
  left: 0;
  background: transparent;
  width: 100%;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
}
.div-box{
  min-height: inherit;
  display: -ms-flexbox;
  display: flex;
  -ms-flex-direction: column;
  flex-direction: column;
  background-color: white;
  margin-bottom: 3px;
}
.div-button{
  width: 100%;
  padding-left: 20px;
  padding-right: 20px;
}
`;