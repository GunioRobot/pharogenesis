moduleUnloaded: aModuleName
	"The module with the given name was just unloaded.
	Make sure we have no dangling references."
	self export: true.
	self var: #aModuleName type: 'char *'.
	(aModuleName strcmp: 'SecurityPlugin') = 0 ifTrue:[
		"The security plugin just shut down. How odd."
		sDSAfn _ sHSAfn _ sCCTPfn _ sCCLOPfn _ sCCSOTfn _ 0.
	].