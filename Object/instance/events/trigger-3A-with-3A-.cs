trigger: anEventSymbol with: aParameter
	"Evaluate all message sends registered for anEventSymbol
	and pass aParamter to the registered actions."

	self trigger: anEventSymbol withArguments: (Array with: aParameter)