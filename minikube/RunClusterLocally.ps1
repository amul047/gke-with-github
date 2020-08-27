Write-Host "-----------------------------starting minikube-----------------------------" -ForegroundColor white
minikube start

Write-Host "-----------------------------recreating cluster----------------------------" -ForegroundColor yellow
kubectl apply -f ../

Write-Host "-----------------------------get local ordering fe url--------------------" -ForegroundColor green
minikube service ordering-fe-service --url
