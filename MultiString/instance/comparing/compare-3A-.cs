compare: aString 
	"Answer a comparison code telling how the receiver sorts relative to aString:
		1 - before
		2 - equal
		3 - after.
"

	^ self multiStringCompare: self with: aString collated: nil
