import React,{useEffect, useState} from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCheck, faCog, faHome, faSearch } from '@fortawesome/free-solid-svg-icons';
import { Col, Row, Form, Button, ButtonGroup, Breadcrumb, InputGroup, Dropdown } from '@themesberg/react-bootstrap';

import { ProductTable } from "../components/Tables";
import {useDispatch, useSelector} from 'react-redux';
import { getAllProductsAsync, setProduct } from "../features/productSlice";
import { deleteProductAsync } from "../features/productSlice";
import { createProductAsync } from "../features/productSlice";
import { useHistory } from "react-router-dom";


export default () => {
  const {products} = useSelector(state => state.product)
  const [valueSearch, setValueSearch] = useState("")
  const dispatch = useDispatch();
  const handleDelete = (id) => {
    dispatch(setProduct(id));
    dispatch(deleteProductAsync({id}));
    console.log(id);
  }
  const handleChange = (e) => {
    setValueSearch(e.target = e.target.value)
  }
  console.log(valueSearch);

  const history = useHistory();
  useEffect(() => {
    dispatch(getAllProductsAsync());
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
 */}          <h4>Product</h4>
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
          <Col xs={8} md={6} lg={3} xl={4}>
            <InputGroup>
              <InputGroup.Text onChange={handleChange}>
                <FontAwesomeIcon icon={faSearch} />
              </InputGroup.Text>
              <Form.Control type="text" placeholder="Search" />
            </InputGroup>
          </Col>
          <Col xs={4} md={2} xl={2} className="ps-md-0 text-end">
            <Button onClick={() => {
                  history.push("/NewProduct")
            }} >New Product</Button>
          </Col>
        </Row>
      </div>

      {products && <ProductTable valueSearch={valueSearch} products={products} handleDelete={handleDelete}/>}
    </>
  );
};
