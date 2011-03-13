flagAttribute: aSymbol
	"Mark the receiver as having the given category-keyword"

	(self attributeKeywords includes: aSymbol) ifFalse: [attributeKeywords add: aSymbol]