copy
	"Make a copy of the receiver without a list of subclasses. Share the 
	reference to the sole instance."

	| copy t |
	t := thisClass.
	thisClass := nil.
	copy := super copy.
	thisClass := t.
	^copy