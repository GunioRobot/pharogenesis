wantsSteps
	"Return true if the receiver overrides the default Morph step method."
	"Details: Find first class in superclass chain that implements #step and return true if it isn't class Morph."

	| c |
	costumee ifNotNil: [^ true].
	c _ self class.
	[c includesSelector: #step] whileFalse: [c _ c superclass].
	^ c ~= Morph