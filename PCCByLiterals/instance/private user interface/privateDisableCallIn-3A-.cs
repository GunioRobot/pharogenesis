privateDisableCallIn: aMethodRef 
	"Disables enabled or failed external prim call by filling function ref 
	literal with special fail value, will be called by superclass."
	aMethodRef compiledMethod literals first at: 4 put: -2