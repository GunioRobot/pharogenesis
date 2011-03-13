list: anArray 
	"Refer to the comment in ListView|list:."

	super list: anArray.
	singleItemMode ifTrue: [selection _ 1]