messagesIn: categoryName 
	"Answer a collection of message ID's for the messages in the given 
	category, sorted in ascending time order.  If the category does not exist, 
	answer an empty collection. The pseudo-categories '.all.' and 
	'.unclassified.' are computed dynamically, which may take a little time."
	| msgList category |
	categoryName = '.unclassified.'
		ifTrue: 
			[Cursor execute showWhile: [msgList _ categoriesFile unclassifiedFrom: indexFile keys].
			^ msgList].
	categoryName = '.all.' ifTrue: [^ indexFile keys].
	"otherwise, it is a real category"
	category _ categoriesFile messagesIn: categoryName.
	^self sortedKeysForMessages: category.
	