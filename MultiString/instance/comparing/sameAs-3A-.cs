sameAs: aString 
	"Answer whether the receiver sorts equal to aString. The 
	collation sequence is ascii with case differences ignored."

	^ (self multiStringCompare: self with: aString asMultiString collated: CaseInsensitiveOrder) = 2.

