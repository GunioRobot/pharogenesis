primitiveCalloutToFFI
	"Perform a function call to a foreign function.
	Only invoked from method containing explicit external call spec.
	Due to this we use the pluggable prim mechanism explicitly here
	(the first literal of any FFI spec'ed method is an ExternalFunction
	and not an array as used in the pluggable primitive mechanism)."
	| function moduleName functionName |
	self var: #function declareC:'static int function = 0'.
	self var: #moduleName declareC:'static char *moduleName = "SqueakFFIPrims"'.
	self var: #functionName declareC:'static char *functionName = "primitiveCallout"'.
	function = 0 ifTrue:[
		function _ self
			ioLoadExternalFunction: (self cCoerce: functionName to:'int')
			OfLength: 16
			FromModule: (self cCoerce: moduleName to:'int')
			OfLength: 14.
		function == 0 ifTrue:[^self primitiveFail]].
	self cCode: '((int (*) (void)) function) ()'.
	self forceInterruptCheck
