atWrap: index 
	"Return this element of an indexable object, letting the index wrap around from the end to the beginning.  See Object at:.  Needed here when index is not an integer and has to be coerced.  "
	<primitive: 63>
	^(super atWrap: index) asCharacter