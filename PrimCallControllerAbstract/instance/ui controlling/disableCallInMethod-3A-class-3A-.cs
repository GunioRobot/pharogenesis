disableCallInMethod: selector class: classOrSymbol 
	"Disables external prim call."
	self
		changeCallMethod: selector
		class: classOrSymbol
		enable: false