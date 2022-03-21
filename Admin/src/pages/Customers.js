import React,{useEffect, useState} from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCheck, faCog, faHome, faSearch } from '@fortawesome/free-solid-svg-icons';
import { Col, Row, Form, Button, ButtonGroup, Breadcrumb, InputGroup, Dropdown } from '@themesberg/react-bootstrap';
import {useDispatch, useSelector} from 'react-redux';

import { CustomerTable } from "../components/Tables";
import { getAllUsersAsync, setCustomer } from "../features/userSlice";

export default () => {
  const {customer} = useSelector(state => state.customer);

  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getAllUsersAsync());
  },[])

  return (
    <>
      <div className="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
        <div className="d-block mb-4 mb-md-0">
{/*           <Breadcrumb className="d-none d-md-inline-block" listProps={{ className: "breadcrumb-dark breadcrumb-transparent" }}>
            <Breadcrumb.Item><FontAwesomeIcon icon={faHome} /></Breadcrumb.Item>
            <Breadcrumb.Item>Volt</Breadcrumb.Item>
            <Breadcrumb.Item active>Transactions</Breadcrumb.Item>
          </Breadcrumb>
 */}          <h4>Customer</h4>
{/*           <p className="mb-0">Your web analytics dashboard template.</p>
 */}        </div>
{/*         <div className="btn-toolbar mb-2 mb-md-0">
          <ButtonGroup>
            <Button variant="outline-primary" size="sm">Share</Button>
            <Button variant="outline-primary" size="sm">Export</Button>
          </ButtonGroup>
        </div>
 */}      </div>

      <div className="table-settings mb-4">
        <Row className="justify-content-between align-items-center">
        </Row>
      </div>

      {customer && <CustomerTable customer={customer}/>}
    </>
  );
};
