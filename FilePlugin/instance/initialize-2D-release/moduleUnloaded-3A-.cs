moduleUnloaded: aModuleName
	"The module with the given name was just unloaded.
	Make sure we have no dangling references."
	self export: true.
	self var: #aModuleName type: 'char *'.
	(aModuleName strcmp: 'SecurityPlugin') = 0 ifTrue:[
		"The security plugin just shut down. How odd."
		sCCPfn _ sCDPfn _ sCGFTfn _ sCLPfn _ sCSFTfn _ sDFAfn _ sCDFfn _ sCOFfn _ sCRFfn _ sHFAfn _ 0.
	].