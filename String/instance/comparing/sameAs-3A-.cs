sameAs: aString 
	"Answer whether the receiver sorts equal to aString. The 
	collation sequence is ascii with case differences ignored."

	| m |
	aString isOctetString ifTrue: [
		^ (self compare: self with: aString asOctetString collated: CaseInsensitiveOrder) = 2
	].
	m _ self asMultiString.
	^ (m compare: m with: aString collated: CaseInsensitiveOrder) = 2
