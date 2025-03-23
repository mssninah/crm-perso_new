dotnet new mvc -n Newapp

cd Newapp

dotnet run 

dotnet dev-certs https --trust


/home/ninah/Eval/Java/git/crm-perso_new/Newapp/Services/LeadService.cs(6,11): error CS0246: The type or namespace name 'Newtonsoft' could not be found (are you missing a using directive or an assembly reference?) [/home/ninah/Eval/Java/git/crm-perso_new/Newapp/Newapp.csproj]

The build failed. Fix the 

dotnet add package Newtonsoft.Json
