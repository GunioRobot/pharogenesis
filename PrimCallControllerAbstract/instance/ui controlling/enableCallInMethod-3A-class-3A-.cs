enableCallInMethod: selector class: classOrSymbol 
	"Enables disabled external prim call."
	self
		changeCallMethod: selector
		class: classOrSymbol
		enable: true