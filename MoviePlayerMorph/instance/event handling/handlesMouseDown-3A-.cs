handlesMouseDown: evt
	"We use shift drag to 'tear off' a thumbnail"

	evt shiftPressed ifTrue: [^ true].
	^ super handlesMouseDown: evt