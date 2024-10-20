echo "Project name: "
read proj_name

cd ..
dotnet new mvc -o $proj_name
dotnet dev-certs https --trust
echo "Setup completed"