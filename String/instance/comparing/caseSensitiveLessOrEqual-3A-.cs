caseSensitiveLessOrEqual: aString 
	"Answer whether the receiver sorts before or equal to aString.
	The collation order is case sensitive."

	| m |
	aString isOctetString ifTrue: [
		^ (self compare: self with: aString asOctetString collated: CaseSensitiveOrder) <= 2
	].
	m _ self asMultiString.
	^ (m compare: m with: aString collated: CaseSensitiveOrder) <= 2
