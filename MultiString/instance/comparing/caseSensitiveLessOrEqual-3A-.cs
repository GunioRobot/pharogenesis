caseSensitiveLessOrEqual: aString 
	"Answer whether the receiver sorts before or equal to aString.
	The collation order is case sensitive."

	^ (self multiStringCompare: self with: aString collated: nil) <= 2
