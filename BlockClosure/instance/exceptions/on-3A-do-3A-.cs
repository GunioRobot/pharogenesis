on: exception do: handlerAction
	"Evaluate the receiver in the scope of an exception handler."

	| handlerActive |
	<primitive: 199>  "just a marker, fail and execute the following"
	handlerActive _ true.
	^ self value