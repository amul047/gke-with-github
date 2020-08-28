Write-Host "-----------------------------starting minikube-----------------------" -ForegroundColor white
minikube start

Write-Host "-----------------------------run skaffold----------------------------" -ForegroundColor green
cd ..
skaffold dev
cd minikube

