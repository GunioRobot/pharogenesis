categoriesThatInclude: msgID
	"Answer a collection of names for real categories that include the message with the given ID. Pseudo-categories (such as '.unclassified.') are not considered real categories."

	^categoriesFile categories select:
		[: catName |
		 (categoriesFile messagesIn: catName) includes: msgID]