fetchNewsFrom: inboxPathName doFormatting: doFormatting deleteInbox: deleteInbox
	"Append the messages from the given news inbox file to this mail database. Answer the number of messages fetched."

	| inbox nextID count msg location |
	"is there any news?"
	((FileDirectory on: inboxPathName) includesKey: 'news') ifFalse: [^ 0].

	inbox _ RNInboxFile openOn: inboxPathName, ':news'.
	nextID _ self nextUnusedID.
	count _ 0.
	messageFile beginAppend.
	inbox newsMessagesDo:
		[: newsgroup : msgText |
		 msg _ MailMessage from: msgText.
		 doFormatting ifTrue: [msg format].
		 location _ messageFile basicAppend: msg text id: nextID.
		 indexFile
			at: nextID
			put: (IndexFileEntry
					message: msg
					location: location
					messageFile: messageFile
					msgID: nextID).
		 categoriesFile file: nextID inCategory: newsgroup.
		 categoriesFile file: nextID inCategory: 'new'.
		 nextID _ nextID + 1.
		 count _ count + 1].
	messageFile endAppend.
	LastID _ nextID.

	"snapshot the database and remove the inbox file"
	self saveDB.
	deleteInbox ifTrue: [inbox delete].
	^ count
