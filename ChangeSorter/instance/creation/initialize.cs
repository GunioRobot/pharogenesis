initialize
	myChangeSet _ Smalltalk changes.		"default"
	classList _ CngsClassList new.
	classList parent: self.
	messageList _ CngsMsgList new.
	messageList parent: self.
	MsgListMenu == nil ifTrue: [self class initialize].
	classList list: #().
	messageList list: #().
