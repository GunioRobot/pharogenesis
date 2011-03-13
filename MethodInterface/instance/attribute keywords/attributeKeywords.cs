attributeKeywords
	"Answer a list of attribute keywords associated with the receiver"

	^ attributeKeywords ifNil: [attributeKeywords := OrderedCollection new]