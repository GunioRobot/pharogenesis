mergeMessages: msgIDList from: sourceDB
	"Merge the given collection of messages from the source database into the receiver. When a message being added has the same message ID as an existing message, check to see if the two message texts are identical. If so, do not store the duplicate message. If the texts are different, make a new ID for the message being added. This operation will also copy the category information from the sourceDB, creating new catetories if necessary."

	| msgText newMsgID saveIt msg location entry |
	messageFile beginAppend.
	msgIDList do:
		[: oldMsgID |
		 msgText _ sourceDB getText: oldMsgID.

		 "resolve ID conflicts"
		 (indexFile includesKey: oldMsgID)
			ifFalse:	"no ID conflict"
				[newMsgID _ oldMsgID.
				 saveIt _ true]
			ifTrue:	"resolve an ID conflict"
				[(msgText = (self getText: oldMsgID))
					ifTrue:	"identical text; don't save again"
						[newMsgID _ oldMsgID.
						 saveIt _ false]
					ifFalse:	"different text; save with new ID"
						[newMsgID _ self nextUnusedID.
						 saveIt _ true]].

		 "save the message in the destination DB"
		 saveIt ifTrue:
			[msg _ MailMessage from: msgText.
			 location _ messageFile basicAppend: msg text id: newMsgID.
			 entry _ IndexFileEntry
						message: msg
						location: location 
						messageFile: messageFile
						msgID: newMsgID.
			 indexFile at: newMsgID put: entry].

		 "update the categories for the message in the destination DB"
		 (sourceDB categoriesThatInclude: oldMsgID) do:
			[: categoryName |
			 self file: newMsgID inCategory: categoryName]].
	messageFile endAppend.