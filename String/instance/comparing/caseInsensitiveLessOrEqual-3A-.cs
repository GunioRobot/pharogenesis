caseInsensitiveLessOrEqual: aString 
	"Answer whether the receiver sorts before or equal to aString.
	The collation order is case insensitive."

	| m |
	aString isOctetString ifTrue: [
		^ (self compare: self with: aString asOctetString collated: CaseInsensitiveOrder) <= 2
	].
	m _ self asMultiString.
	^ (m compare: m with: aString collated: CaseInsensitiveOrder) <= 2
