Write-Host "-----------------------------starting minikube-----------------------------" -ForegroundColor white
minikube start

Write-Host "-----------------------------recreating cluster----------------------------" -ForegroundColor yellow
kubectl apply -f ../

Write-Host "-----------------------------get local ordering api url--------------------" -ForegroundColor green
minikube service ordering-api-service --url
