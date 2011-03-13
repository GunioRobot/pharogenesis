sameAs: aString 
	"Answer whether the receiver sorts equal to aString. The 
	collation sequence is ascii with case differences ignored."

	^ (self compare: self with: aString collated: CaseInsensitiveOrder) = 2