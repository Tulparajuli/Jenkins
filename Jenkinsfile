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
        bat 'dotnet /t:package JenkinsMVC.csproj --out ../Package'
      }
    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('deploy') {
    try {

    } catch(error) {
      //slackSend message: color:'danger'
    }
  }
}
