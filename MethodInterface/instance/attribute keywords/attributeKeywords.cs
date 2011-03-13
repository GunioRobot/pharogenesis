attributeKeywords
	"Answer a list of attribute keywords associated with the receiver"

	^ attributeKeywords ifNil: [attributeKeywords _ OrderedCollection new]