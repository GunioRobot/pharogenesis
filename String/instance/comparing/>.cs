> aString 
	"Answer whether the receiver sorts after aString.
	The collation order is simple ascii (with case differences)."


	| m |
	aString isOctetString ifTrue: [
		^ (self compare: self with: aString asOctetString collated: AsciiOrder) = 3
	].
	m _ self asMultiString.
	^ (m compare: m with: aString collated: nil) = 3
