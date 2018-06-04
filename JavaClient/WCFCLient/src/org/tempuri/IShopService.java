/**
 * IShopService.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package org.tempuri;

public interface IShopService extends java.rmi.Remote {
    public org.datacontract.schemas._2004._07.ShopLibrary.Product[] getAllProducts() throws java.rmi.RemoteException;
    public java.lang.Boolean register(java.lang.String username) throws java.rmi.RemoteException;
    public java.lang.Double getBalance(java.lang.Integer userid) throws java.rmi.RemoteException;
    public java.lang.String test() throws java.rmi.RemoteException;
    public java.lang.Boolean isUsernameUnique(java.lang.String username) throws java.rmi.RemoteException;
    public org.datacontract.schemas._2004._07.ShopLibrary.User login(java.lang.String username, java.lang.String password) throws java.rmi.RemoteException;
    public java.lang.Boolean buyProduct(java.lang.Integer prodid, java.lang.Integer amount) throws java.rmi.RemoteException;
    public org.datacontract.schemas._2004._07.ShopLibrary.Product[] getUserOwnedProducts(java.lang.Integer userid) throws java.rmi.RemoteException;
}
