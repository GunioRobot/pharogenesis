generateScriptAndUpdateMethodForNewVersion
	"Use me to generate the script and update method"
	"self new generateScriptAndUpdateMethodForNewVersion"
	
	self compileScriptMethodWithCurrentPackages: self currentScriptVersionNumber.
	self compileNewUpdateMethod.