initialize
	"Register the receiver with MorphicTextEditor in the AppRegistry.
	If the old default was a plain old PluggableTextMorph, then make the receiver the new default, otherwise make the default nil so that the user is prompted"
	| current |
	
	current := MorphicTextEditor defaultOrNil.
	(current isNil or: [current = PluggableTextMorph or: [current = self]])
		ifTrue:[MorphicTextEditor default: self]
		ifFalse:[	MorphicTextEditor register: self; default: nil]