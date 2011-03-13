on: exception do: handlerAction
	"Evaluate the receiver in the scope of an exception handler."
	| handlerActive |
	handlerActive _ true.
	^self value