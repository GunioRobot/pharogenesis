on: exception do: handlerAction
	"Evaluate the receiver in the scope of an exception handler."
	| handlerActive |
	<primitive: 199>
	handlerActive _ true.
	^self value