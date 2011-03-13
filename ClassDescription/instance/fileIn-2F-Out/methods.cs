methods
	"Answer a ClassCategoryReader for accessing the messages in the method dictionary category, 'as yet unclassified', of the receiver.  Used for filing in fileouts made with Smalltalk/V"

	^ClassCategoryReader class: self category: 'imported from V' asSymbol