new
	"Return a copy of the prototype, if there is one.
	Otherwise create a new instance normally."

	self hasPrototype ifTrue: [^ prototype fullCopy].
	^ super new
