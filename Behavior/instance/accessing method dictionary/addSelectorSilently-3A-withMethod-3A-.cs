addSelectorSilently: selector withMethod: compiledMethod 
	"Add the message selector with the corresponding compiled method to the 
	receiver's method dictionary.
	Do this without sending system change notifications"

	| oldMethodOrNil |
	oldMethodOrNil _ self lookupSelector: selector.
	self methodDict at: selector put: compiledMethod.

	"Now flush Squeak's method cache, either by selector or by method"
	oldMethodOrNil == nil ifFalse: [oldMethodOrNil flushCache].
	selector flushCache.