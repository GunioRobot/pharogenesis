moduleUnloaded: aModuleName
	"The module with the given name was just unloaded.
	Make sure we have no dangling references."
	self export: true.
	self var: #aModuleName type: 'char *'.
	(aModuleName strcmp: bbPluginName) = 0 ifTrue:[
		"BitBlt just shut down. How nasty."
		loadBBFn _ 0.
		copyBitsFn _ 0.
	].