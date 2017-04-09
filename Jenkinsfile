#!groovy
node {
    def buildArtifacts = "buildartifacts"
    def buildArtifactsDir = "${env.WORKSPACE}\\$buildArtifacts"
    def solutionName = 'watchshop.sln'
    timestamps {
        stage('Checkout') {
         //   git 'https://github.com/khdevnet/REST.git'
        }

        stage('Build') {
           // log("Clean buildartifacts: ${buildArtifactsDir}")
          //  removeDir(buildArtifactsDir)
          //  bat "\"${tool 'nuget'}\" restore $solutionName"
          //  bat "\"${tool 'msbuild'}\" $solutionName  /p:DeployOnBuild=true;DeployTarget=Package /p:Configuration=Release;OutputPath=\"$buildArtifactsDir\" /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
        }

        stage('Tests') {
          def testFilesName = getFiles("$buildArtifacts/*.Tests.dll", buildArtifactsDir).join(' ')
          echo testFilesName 
           // bat """${tool 'nunit'} %testFiles%"""
        }

        stage('Archive') {
            archiveArtifacts artifacts: 'buildartifacts/_PublishedWebsites/WatchShop.Api_Package/**/*.*', onlyIfSuccessful: true
        }

        stage('Notifications') {
            emailext body: 'Test', subject: 'Test', to: 'khdevnet@gmail.com'
        }
    }
}
def getFiles(wildcard, rootDir=''){ 
    def files = findFiles(glob: wildcard)
    def names = []
    def prefix = rootDir == '' ? '' : rootDir + '\\'
    for(def file : files ) { names << prefix + file.name }
    return names
}
def removeDir(dirPath) {
     def dir = new File(dirPath)
     if (dir.exists()) dir.deleteDir()
 }
def log(message){
    println message
} 
