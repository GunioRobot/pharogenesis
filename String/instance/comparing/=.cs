= aString 
	"Answer whether the receiver sorts equally as aString.
	The collation order is simple ascii (with case differences)."

	(aString class == String or: [aString class == Symbol]) ifFalse: [
		aString class == MultiString ifTrue: [^ aString = self].
		aString isText ifTrue: [^ self = aString string].
		^ false
	].

	^ (self compare: self with: aString collated: AsciiOrder) = 2.
