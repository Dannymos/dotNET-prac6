package org.tempuri;

public class IShopServiceProxy implements org.tempuri.IShopService {
  private String _endpoint = null;
  private org.tempuri.IShopService iShopService = null;
  
  public IShopServiceProxy() {
    _initIShopServiceProxy();
  }
  
  public IShopServiceProxy(String endpoint) {
    _endpoint = endpoint;
    _initIShopServiceProxy();
  }
  
  private void _initIShopServiceProxy() {
    try {
      iShopService = (new org.tempuri.ShopServiceLocator()).getBasicHttpBinding_IShopService();
      if (iShopService != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iShopService)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iShopService)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iShopService != null)
      ((javax.xml.rpc.Stub)iShopService)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public org.tempuri.IShopService getIShopService() {
    if (iShopService == null)
      _initIShopServiceProxy();
    return iShopService;
  }
  
  public org.datacontract.schemas._2004._07.ShopLibrary.Product[] getAllProducts() throws java.rmi.RemoteException{
    if (iShopService == null)
      _initIShopServiceProxy();
    return iShopService.getAllProducts();
  }
  
  public java.lang.Boolean register(java.lang.String username) throws java.rmi.RemoteException{
    if (iShopService == null)
      _initIShopServiceProxy();
    return iShopService.register(username);
  }
  
  public java.lang.Double getBalance(java.lang.Integer userid) throws java.rmi.RemoteException{
    if (iShopService == null)
      _initIShopServiceProxy();
    return iShopService.getBalance(userid);
  }
  
  public java.lang.String test() throws java.rmi.RemoteException{
    if (iShopService == null)
      _initIShopServiceProxy();
    return iShopService.test();
  }
  
  public java.lang.Boolean isUsernameUnique(java.lang.String username) throws java.rmi.RemoteException{
    if (iShopService == null)
      _initIShopServiceProxy();
    return iShopService.isUsernameUnique(username);
  }
  
  public org.datacontract.schemas._2004._07.ShopLibrary.User login(java.lang.String username, java.lang.String password) throws java.rmi.RemoteException{
    if (iShopService == null)
      _initIShopServiceProxy();
    return iShopService.login(username, password);
  }
  
  public java.lang.Boolean buyProduct(java.lang.Integer prodid, java.lang.Integer amount) throws java.rmi.RemoteException{
    if (iShopService == null)
      _initIShopServiceProxy();
    return iShopService.buyProduct(prodid, amount);
  }
  
  public org.datacontract.schemas._2004._07.ShopLibrary.Product[] getUserOwnedProducts(java.lang.Integer userid) throws java.rmi.RemoteException{
    if (iShopService == null)
      _initIShopServiceProxy();
    return iShopService.getUserOwnedProducts(userid);
  }
  
  
}