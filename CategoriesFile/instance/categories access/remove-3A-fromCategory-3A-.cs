remove: messageID fromCategory: categoryName
	"Remove the given message ID from the given category."

	| msgList |
	msgList _ categories at: categoryName ifAbsent: [^self].
	msgList remove: messageID ifAbsent: [].