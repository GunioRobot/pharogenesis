messagesIn: categoryName 
	"Answer a collection of message ID's for the messages in the given 
	category, sorted in ascending time order.  If the category does not exist, 
	answer an empty collection. The pseudo-categories '.all.' and 
	'.unclassified.' are computed dynamically, which may take a little time."
	| msgList |
	categoryName = '.unclassified.'
		ifTrue: 
			[Cursor execute showWhile: [msgList _ self categorizer unclassifiedFrom: indexFile keys].
			^ msgList].
	categoryName = '.all.' ifTrue: [^ self allMessages ].
	"otherwise, it is a real category"
	^ self categorizer at: categoryName