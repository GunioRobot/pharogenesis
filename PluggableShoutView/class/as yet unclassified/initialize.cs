initialize
	"Register the receiver with MvcTextEditor in the AppRegistry.
	If the old default was a plain old PluggableTextView, then make the receiver the new default, otherwise make the default nil so that the user is prompted.
	This is run after the monticello package is loaded"
	| current |
	
	current := MvcTextEditor defaultOrNil.
	(current isNil or: [current = PluggableTextView or: [current = self]])
		ifTrue:[MvcTextEditor default: self]
		ifFalse:[	MvcTextEditor register: self; default: nil]