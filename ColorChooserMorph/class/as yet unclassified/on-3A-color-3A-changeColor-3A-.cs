on: anObject color: getSel changeColor: setSel
	"Answer a new instance of the receiver on the given model using
	the given selectors as the interface."

	^self new
		on: anObject 
		color: getSel
		changeColor: setSel