compileScriptMethodWithCurrentPackages: aNumber 
	"ScriptLoader new compileScriptMethodWithCurrentPackages: 9999"
	
	self class compile: 
		(self generateScriptTemplateWithCurrentPackages: aNumber)
		classified: 'scripts'