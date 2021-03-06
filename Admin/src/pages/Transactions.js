import React,{useEffect, useState} from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCheck, faCog, faHome, faSearch } from '@fortawesome/free-solid-svg-icons';
import { Col, Row, Form, Button, ButtonGroup, Breadcrumb, InputGroup, Dropdown } from '@themesberg/react-bootstrap';

import { TransactionsTable } from "../components/Tables";
import {useDispatch, useSelector} from 'react-redux';
import { getAllCategoriesAsync, setCategory } from "../features/categorySlice";
import { deleteCategoryAsync } from "../features/categorySlice";
import { createCategoryAsync } from "../features/categorySlice";

export default () => {
  const {categories} = useSelector(state => state.category)
  const [isCreated, setIsRelated] = useState(false);
  const [valueForm, setValueForm] = useState({
    categoryName: "",
    content: ""
  })
  const dispatch = useDispatch();
  const handleDelete = (id) => {
    dispatch(setCategory(id));
    dispatch(deleteCategoryAsync({id}));
  }
  const handleCreateCategory = (e) => {
    e.preventDefault()
    dispatch(createCategoryAsync(valueForm))
  }
  const handleCreate = () => {
    setIsRelated(true)
  }
  const handleShow = () => {
    setIsRelated(false)
  }
  
useEffect(() => {
  dispatch(getAllCategoriesAsync());
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
 */}          <h4>Category</h4>
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
              <InputGroup.Text>
                <FontAwesomeIcon icon={faSearch} />
              </InputGroup.Text>
              <Form.Control type="text" placeholder="Search" />
            </InputGroup>
          </Col>
          <Col xs={4} md={2} xl={1} className="ps-md-0 text-end">
            <Dropdown as={ButtonGroup}>
              <Dropdown.Toggle split as={Button} variant="link" className="text-dark m-0 p-0">
                <span className="icon icon-sm icon-gray">
                  <FontAwesomeIcon icon={faCog} />
                </span>
              </Dropdown.Toggle>
              <Dropdown.Menu className="dropdown-menu-xs dropdown-menu-right">
                <Dropdown.Item className="fw-bold" onClick={handleShow} >List</Dropdown.Item>
                <Dropdown.Item className="fw-bold" onClick={handleCreate} >New</Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown>
          </Col>
        </Row>
      </div>

      {categories && <TransactionsTable isCreate={isCreated} valueForm={valueForm} handleCreateCategory={handleCreateCategory} setValueForm={setValueForm} categories={categories} handleDelete={handleDelete}/>}
    </>
  );
};
