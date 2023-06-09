# ReventBookings

<h2>This project is about a simple .Net API application that is deployed on Kubernetes cluster.</h2>
<h4>This API application has the following endpoints:</h4>
<ul>
  <li>Create task</li>
  <li>Update task</li>
  <li>Delete task</li>
  <li>View task</li>
</ul>

An automation is built to manage the deployment lifecycle of the application on a Kubernetes cluster and expose the API outside the cluster.

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



