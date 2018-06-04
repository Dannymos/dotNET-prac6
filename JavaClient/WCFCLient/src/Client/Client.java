package Client;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.List;

import org.datacontract.schemas._2004._07.ShopLibrary.User;
import org.datacontract.schemas._2004._07.ShopLibrary.Product;
import org.tempuri.IShopServiceProxy;

public class Client {
	
	public static String command = "";
	public static IShopServiceProxy proxy=new IShopServiceProxy();
    public static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	
	
    
    
    public static void main(String[] args) throws RemoteException{
    		User user = null;
         
      

         try {
             

             while (true) {

            	 System.out.print("Type 1 to Log-in, type 2 to sign-up: \n");
            	 command = br.readLine();
                 if (command.equals("1")) {

                     user = Login();
                     if (user != null) {
                    	 System.out.print("Logged in succesfully \n\n");
                     }
                     else {
                    	 System.out.print("Wrong Username/Password \n");
                    	 break;
                     }
                  
                 }
                 else if (command.equals("2")) {
                	 System.out.print(Register() + "\n");
                 }
                 Product[] list = proxy.getAllProducts();
                 Product[] list2 = user.getOwnedProducts();
                 
                 System.out.print("Available products in shop: \n");
                 int item = 0;
                 for (Product product : list) {
                	 item++;
                	 System.out.print(item + ". "+ product.getName() + " Stock: " + product.getStock() + " Price: " + product.getPrice() + "\n");
                	 
                 }
                 System.out.print("\n");
                 if (list2 != null) {
                	 for (Product product : list2) {
                		 System.out.print(product.getName() + " Stock: " + product.getStock()  + "\n");
                	 
                	 }
                 }
                 else {
                	 System.out.print("You don't have any products");
                 }
                 System.out.print("\n\n");
                 System.out.print("Users balance: " + user.getBalance() + "\n");
                 
                 
                 System.out.print("\nWhat item do you want to buy?\n");
                 String kopen = br.readLine();
                 System.out.print("How many do you want?\n");
                 String hvl = br.readLine();
                 proxy.buyProduct(list[Integer.parseInt(kopen)- 1].getId(), Integer.parseInt(hvl));
             }

         }
         catch (IOException e) {
             e.printStackTrace();
         }
     }
    public static User Login() throws IOException {
    	System.out.print("Username: \n");
        String username = br.readLine();
        System.out.print("Password: \n");
        String password = br.readLine();
        return proxy.login(username, password);
    }
    
    public static boolean Register() throws IOException {
    	System.out.print("New Username: \n");
    	String username = br.readLine();
    	return proxy.register(username);
    }
  
    
}