instanceVariableValues
	"MorphicModel76 someInstance instanceVariableValues"
	| c |
	c _ OrderedCollection new.
	self class superclass instSize + 1 to: self class instSize do:
		[:i | c add: (self instVarAt: i)].
	^ c