node('master') {
  stage('import') {
    try {
      git credentialsId: '5215a79d-f864-4294-97e9-fa1b217e8cab', url: 'https://github.com/Tulparajuli/Jenkins.git'
    } catch(error) {
      //slackSend message:{env.BUILD_NUMBER} color:'danger'
    }
  }

  stage('build') {
    try {

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
