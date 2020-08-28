# Deploying to GKE with github actions
A simple multi tier application deployed to GKE
- currently has two API layers (Ordering.api - exposed, Supplier.Api - internal)

## To run a single API locally
Use dotnet core commands of your favourite SDK (such as Visual Studio)

## To run the application locally
Follow the instructions on https://github.com/amul047/gke-with-github/blob/master/minikube/HowToRunKubernetesLocally.md

## To deploy to GKE
1. Create a clsuter in GKE as per the instructions here - https://cloud.google.com/kubernetes-engine/docs/quickstart (it is not essential for you to follow the deplying application steps, as this repository is designed to deploy on commit to master)
2. Follow the commented instructions on top of this file - https://github.com/amul047/gke-with-github/blob/master/.github/workflows/google.yml
