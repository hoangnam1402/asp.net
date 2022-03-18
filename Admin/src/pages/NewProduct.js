import React,{useEffect, useState} from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCheck, faCog, faHome, faSearch } from '@fortawesome/free-solid-svg-icons';
import { Col, Row, Form, Button, ButtonGroup, Breadcrumb, InputGroup, Dropdown, Card } from '@themesberg/react-bootstrap';

import {useDispatch, useSelector} from 'react-redux';
import { createProductAsync } from "../features/productSlice";
import { getAllCategoriesAsync, setCategory } from "../features/categorySlice";

export default () => {
  const {categories} = useSelector(state => state.category)
  const [valueForm, setValueForm] = useState({
    name: "",
    description: "",
    cost: 0,
    quantity: 0,
    stopped: false,
    categoryId: "",
    pic1: "",
    pic2: "",
    pic3: "",
    pic4: "",
    isPublished: false,
  })
  
  const dispatch = useDispatch();
  const handleCreateProduct = (e) => {
    e.preventDefault()
    dispatch(createProductAsync(valueForm))
  }
  const handleChange = (e) => {
    setValueForm({...valueForm, [e.target.name]: e.target.value})
  }
  useEffect(() => {
    dispatch(getAllCategoriesAsync());
  },[])
  console.log(valueForm);
  console.log(categories);

  return (
    <>
      <div className="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center py-4">
        <div className="d-block mb-4 mb-md-0">
          <h4>Create Product</h4>
        </div>
      </div>
      <div className="table-settings mb-4">
        <Card border="light" className="bg-white shadow-sm mb-4">
          <Card.Body>
            <Form>
              <Row>
                <Col md={6} className="mb-3">
                  <Form.Group id="name">
                    <Form.Label>Name</Form.Label>
                    <Form.Control name="name" onChange={handleChange} required type="text" placeholder="Enter product name" />
                  </Form.Group>
                </Col>
              </Row>
              <Row>
                <Col md={12} className="mb-3">
                  <Form.Group id="description">
                    <Form.Label>Description</Form.Label>
                    <Form.Control name="description" onChange={handleChange} required type="text" placeholder="Enter product description" />
                  </Form.Group>
                </Col>
              </Row>
              <Row className="align-items-center">
                <Col md={3} className="mb-3">
                  <Form.Group id="cost">
                    <Form.Label>Price</Form.Label>
                    <Form.Control name="cost" onChange={handleChange} required type="number" placeholder="Enter product price" />
                  </Form.Group>
                </Col>
                <Col md={3} className="mb-3">
                  <Form.Group id="quantity">
                    <Form.Label>Quantity</Form.Label>
                    <Form.Control name="quantity" onChange={handleChange} required type="number" placeholder="Enter product quantity" />
                  </Form.Group>
                </Col>
                <Col md={3} className="mb-3">
                  <Form.Group id="stopped">
                    <Form.Label>Stop sale</Form.Label>
                    <Form.Select name="stopped" onChange={(e) => { 
                      setValueForm({
                        ...valueForm, [e.target.name]: e.target.value === "true" 
                      });
                    }} defaultValue={"false"}>
                      <option value="true">Yes</option>
                      <option value="false">No</option>
                    </Form.Select>
                  </Form.Group>
                </Col>
                <Col md={3} className="mb-3">
                  <Form.Group id="isPublished">
                    <Form.Label>Published</Form.Label>
                    <Form.Select name="isPublished" onChange={(e) => { 
                      setValueForm({
                        ...valueForm, [e.target.name]: e.target.value === "true" 
                      });
                    }} defaultValue={"false"}>
                      <option value={"true"}>Yes</option>
                      <option value={"false"}>No</option>
                    </Form.Select>
                  </Form.Group>
                </Col>
              </Row>
              <Row>
                <Col md={6} className="mb-3">
                  <Form.Group id="categoryId">
                    <Form.Label>Category</Form.Label>
                    <Form.Select name="categoryId" onChange={handleChange} defaultValue="">
                      {categories?.map(item => 
                        <option value={item.id}>{item.categoryName}</option>
                      )}
                      <option value="">Don't have</option>
                    </Form.Select>
                  </Form.Group>
                </Col>
              </Row>
              <Row>
                <Col md={12} className="mb-3">
                  <Form.Group id="pic1">
                    <Form.Label>Product Picture</Form.Label>
                    <Form.Control name="pic1" onChange={handleChange} required type="text" placeholder="Enter product picture 1 url" />
                  </Form.Group>
                </Col>
              </Row><Row>
                <Col md={12} className="mb-3">
                  <Form.Group id="pic2">
                    <Form.Control name="pic2" onChange={handleChange} required type="text" placeholder="Enter product picture 2 url" />
                  </Form.Group>
                </Col>
              </Row><Row>
                <Col md={12} className="mb-3">
                  <Form.Group id="pic3">
                    <Form.Control name="pic3" onChange={handleChange} required type="text" placeholder="Enter product picture 3 url" />
                  </Form.Group>
                </Col>
              </Row><Row>
                <Col md={12} className="mb-3">
                  <Form.Group id="pic4">
                    <Form.Control name="pic4" onChange={handleChange} required type="text" placeholder="Enter product picture 4 url" />
                  </Form.Group>
                </Col>
              </Row>
              <div className="mt-3">
                <Button onClick={handleCreateProduct} variant="primary" type="submit">Create</Button>
              </div>
            </Form>
          </Card.Body>
        </Card>
      </div>
    </>
  );
};
