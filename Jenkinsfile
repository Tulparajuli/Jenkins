node('master') {
  stage('import') {
    try {
     // slackSend "started ${env.JOB_NAME} ${env.BUILD_NUMBER} (<${env.BUILD_URL}|Open>)"
      git credentialsId: 'github-jinkens', url: 'https://github.com/Tulparajuli/Jenkins.git'
    } catch(error) {
      //slackSend message:{env.BUILD_NUMBER} color:'danger'
      
    }
  }

  stage('build') {
    try {
      //do build for msbuild
      dir('JenkinsMVC'){
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

    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('test') {
    try {

    } catch(error) {
      //slackSend message: color:'danger'
    }
  }

  stage('package') {
    try {

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
