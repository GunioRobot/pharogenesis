< aString 
	"Answer whether the receiver sorts before aString.
	The collation order is simple ascii (with case differences)."

	| m |
	aString isOctetString ifTrue: [
		^ (self compare: self with: aString asOctetString collated: AsciiOrder) = 1
	].
	m _ self asMultiString.
	^ (m compare: m with: aString collated: nil) = 1
