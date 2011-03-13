bindTemp: name
	"Declare a temporary; error not if a field or class variable or out-of-scope temp.
	 Read the comment in Encoder>>bindBlockArg:within: and subclass implementations."
	self supportsClosureOpcodes ifFalse:
		[^super bindTemp: name].
	scopeTable at: name ifPresent:
		[:node|
		"When non-interactive raise the error only if it is a duplicate"
		node isTemp
			ifTrue:[node scope >= 0 ifTrue:
						[^self notify:'Name is already defined']]
			ifFalse:[self warnAboutShadowed: name]].
	^self reallyBind: name