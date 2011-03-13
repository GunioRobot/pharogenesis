methodsForNewVersion
	"self new methodsForNewVersion"
	
	self compileScriptMethodWithCurrentPackages: (self getLatestScriptNumber + 1).
	self compileNewUpdateMethod.