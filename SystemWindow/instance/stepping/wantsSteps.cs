wantsSteps
	"Return true if the model responds to step (except if it is a debugger)."
	| c |
	c _ model class.
	[c == nil] whileFalse:
		[(c includesSelector: #step) ifTrue: [^ c ~= Debugger].
		c _ c superclass].
	^ false