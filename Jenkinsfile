node('master') {
  stage('import') {
    try {
     slackSend "started ${env.JOB_NAME} ${env.BUILD_NUMBER} (<${env.BUILD_URL}|Open>)"
      git credentialsId: 'github-jinkens', url: 'https://github.com/Tulparajuli/Jenkins.git'
      //use credentialsid if private repo
    } catch(error) {
      //slackSend message:{env.BUILD_NUMBER} color:'danger'
      
    }
  }

  stage('build') {
    try {
      //do build for msbuild
      dir('JenkinsMVC'){
        //this is for nuget if not solution there
      //bat 'nuget restore'
      bat 'dotnet restore'
      bat 'msbuild /t:clean, build JenkinsMVC.csproj'
    }
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('analyze') {
    try {
      //get key from sonarcloud
      //C:\Tools\SonarQube
      dir('JenkinsMVC'){
        bat 'C:\\Tools\\SonarQube\\SonarQube.Scanner.MSBuild.exe begin /k:winmvc'
       //bat 'dotnet build'
       bat 'msbuild /t:build JenkinsMVC.csproj'
        bat 'C:\\Tools\\SonarQube\\SonarQube.Scanner.MSBuild.exe end'
      }
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('test') {
    try {
   dir('JenkinsMVC.Tests'){
        
       bat 'dotnet test'
       //for msbuild
       //bat 'msbuild /t:build JenkinsMVC.Tests.csproj'
       
      }
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('package') {
    try {
     dir('JenkinsMVC') {
        //bat 'msbuild /t:package JenkinsMVC.csproj'
        //bat 'dotnet pack JenkinsMVC.csproj --output ../Package'
        bat 'dotnet publish JenkinsMVC.csproj --output ../Package'
        bat 'msbuild /t:pack JenkinsMVC.csproj'
      }
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('deploy') {
    try {
         // dir('JenkinsMVC') {
           bat 'dotnet build ./JenkinsMVC/JenkinsMVC.csproj /p:DeployOnBuild=true /p:PublishProfile=publish'
         // bat '"C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:iisApp="C:\\Program Files (x86)\\Jenkins\\workspace\\jenkinsops\\Package\\" -dest:iisApp="Default Web Site/jenkinsops",computerName=ec2-18-144-22-120.us-west-1.compute.amazonaws.com:8172/msdeploy.axd,username=Administrator,password="U.Oe(D%cldYlMrIzY=J-u8cO;zGS;pjr" -allowUntrusted -enableRule:AppOffline'
          // bat 'dotnet build ./JenkinsMVC/JenkinsMVC.csproj /p:DeployOnBuild=true /p:PublishProfile=publish'
          bat '"C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:iisApp="C:\\Program Files (x86)\\Jenkins\\workspace\\jenkins-win\\Package" -dest:iisApp="Default Web Site/jenkins-win",computername=https://ec2-52-90-124-176.compute-1.amazonaws.com:8172/msdeploy.axd,username=EC2AMAZ-KKDF9LE\Administrator,password=winPassword1,AuthType=basic -allowUntrusted  -enableRule:AppOffline'
     // }
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }
}
