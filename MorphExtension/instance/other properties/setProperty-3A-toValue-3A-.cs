setProperty: propName toValue: aValue
	"These special cases move old properties into named fields of the extension"
	otherProperties == nil ifTrue: [otherProperties _ IdentityDictionary new].
	otherProperties at: propName put: aValue.
