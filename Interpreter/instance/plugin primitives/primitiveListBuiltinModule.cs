primitiveListBuiltinModule
	"Primitive. Return the n-th builtin module name."
	| moduleName index length nameOop |
	self var: #moduleName type: 'char *'.
	self methodArgumentCount = 1 ifFalse:[^self primitiveFail].
	index _ self stackIntegerValue: 0.
	index <= 0 ifTrue:[^self primitiveFail].
	moduleName _ self ioListBuiltinModule: index.
	moduleName == nil ifTrue:[
		self pop: 2. "arg+rcvr"
		^self push: self nilObject].
	length _ self strlen: moduleName.
	nameOop _ self instantiateClass: self classString indexableSize: length.
	0 to: length-1 do:[:i|
		self storeByte: i ofObject: nameOop withValue: (moduleName at: i)].
	self forceInterruptCheck.
	self pop: 2 thenPush: nameOop