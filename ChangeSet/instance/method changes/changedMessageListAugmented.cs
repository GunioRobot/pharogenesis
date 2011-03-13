changedMessageListAugmented
	"In addition to changedMessageList, put all messages for all added classes in the ChangeSet."
	^ self changedMessageList asArray, self allMessagesForAddedClasses