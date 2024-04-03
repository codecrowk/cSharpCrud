##----- Varibles
# For inheritence a varible you have to execute this script from env.sh, to use those varibles
## Local varibles
declare currentFolder="Documents"
# Here it should be equal to github repository
declare rootDirectoryName="Products"

# declare rootDirectoryFullName="$rootDirectoryName\Project"
export rootDirectoryFullName="${rootDirectoryName}Project"

## Export varible
export solutionName="Products"
export projectType="mvc"
export projectIdentifier="Mvc"
export projectName="$solutionName.$projectIdentifier"

## Tree folding
export rootProject="$HOME/$currentFolder/$rootDirectoryFullName"
export solutionFolder="${rootProject}/${solutionName}"

# echo $solutionName
source ./startGitRepository.sh