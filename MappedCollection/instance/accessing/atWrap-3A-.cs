atWrap: anIndex 
	"Return this element of an indexable object.  If index is out of bounds, let it wrap around from the end to the beginning unil it is in bounds.  6/18/96 tk"

	^domain at: (map atWrap: anIndex)