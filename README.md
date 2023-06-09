# ReventBookings

<h2>This project is about a simple .Net API application that is deployed on Kubernetes cluster.</h2>
<h4>This API application uses an in-memory database has the following endpoints:</h4>
<ul>
  <li>Create task</li>
  <li>Update task</li>
  <li>Delete task</li>
  <li>View task</li>
</ul>

An automation is built to manage the deployment lifecycle of the application on a Kubernetes cluster and expose the API outside the cluster.

<p>This project was completed locally. To repo it, you will have to download docker desktop if you don't have it installed already, it will run your docker and kubernetes.

The steps to achieve this include:
<ul>
  <li>Creating a Dockerfile</li>
  <li>Creating a Kubernetes file (Deyployment.yml)</li>
</ul>

<h4>The Dockerfile:</h4>
<p>This Dockerfile build the application on a base image. In this project an SDK of .Net 6 was used. The working directort inside the container is set to /app. <br>
Port 80 was exposed for inbound connections and 443 for secure connection.<br>
Once the Nuget packages are restored, and the app is published (i.e., compiling code and resolving dependencies to a ready-to-publish version of the app), a final image is made.<br>
An entrypoint ["dotnet", "ReventBookings.dll"] is specified. The command that will be executed when the container starts. </p>
<p>Once the app is successfully test on the container, it will be pushed to a docker hub account. This is done so Kubernetes can pull the image from the hub</p>

<h4>The Deployment.yml file:</h4>
<p>For simplicity, this file has two sections. The first deploy the app to kubernetes and the second exposes the API outside the cluster.
This file exposes the container to Port 80, allocates some amounts of CPU and Memory, while setting up limits as well. It has 4 replicas (pods).
<p>The second part (identified by the three dashes) is a load balancer that directs traffic to the application on the kubernetes cluster via ports 8080.
  
The final look of the app as seen via kubernetes port 8080, to be precise: http://localhost:8080/swagger/index.html

  ![image](https://github.com/Toch-vybe/ReventBookings/assets/60288017/3884a22c-c303-4f46-9b23-5a48ec4148f8)


<h2>Details of the App</h2>
If you have not used a .Net API before, walk with me, lets try it out.
<p> For creating, select the Post and click "try it out".
![image](https://github.com/Toch-vybe/ReventBookings/assets/60288017/f07afb88-3526-426e-961b-3a5b7ad4af08)
<p>Edit **only** the name and message value with placeholder of "string" and hit execute. You will get a 200 status code with an output like below:
![image](https://github.com/Toch-vybe/ReventBookings/assets/60288017/8ca8b4c8-840c-4e2b-8a36-f8a85fb965af)
  
<p> To view existing booking, select the View and click "try it out" same as the previous step. Put the Id you get in the previous step, and you should get an output similar to the image above.
  
<p> For updating a booking, input the ID and fill the response body with details. You output should be as below:
![image](https://github.com/Toch-vybe/ReventBookings/assets/60288017/7a22ca97-50b3-45b4-bef0-4ad813871690)
If you view the booking again you would get the update version.
  
<p>For deleting a booking, just specifiy the ID and it will be deleted with a status code of 200




