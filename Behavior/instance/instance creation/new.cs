new
	"Answer a new instance of the receiver (which is a class) with no indexable variables. Fail if the class is indexable."

	<primitive: 70>  "This method runs primitively if successful"
	^ self basicNew  "Exceptional conditions will be handled in basicNew"
