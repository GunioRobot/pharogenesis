removeMessagesInCategory: categoryName butNotIn: indexFile
	"Used to clean the dead wood out of a category."

	| oldMsgs newMsgs |
	oldMsgs _ categories at: categoryName ifAbsent: [^self].
	newMsgs _ oldMsgs copy.
	oldMsgs do:
		[: msgID |
		 (indexFile includesKey: msgID) ifFalse:
			[newMsgs remove: msgID]].
	categories at: categoryName put: newMsgs.