##----- Import
# For inheritence a varible you have to execute this script from env.sh, to use those varibles

## Local varibles
declare gitignore=".gitignore"

## Go to root directory
# cd $solutionFolder
cd $rootProject

touch $gitignore
echo -e "${solutionName}/${projectName}/obj" >> $gitignore
echo -e "${solutionName}/${projectName}/bin" >> $gitignore

git init
git add .
git commit -m 'Start project from scratch'