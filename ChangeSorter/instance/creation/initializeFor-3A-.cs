initializeFor: aChangeSet
	"Initialize the receiver and have it start out life looking at aChangeSet.  "

	myChangeSet _ aChangeSet.	
	classList _ CngsClassList new.
	classList parent: self.
	messageList _ CngsMsgList new.
	messageList parent: self.
	MsgListMenu == nil ifTrue: [self class initialize].
	classList list: #().
	messageList list: #().
