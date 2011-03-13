categoryMenu: aMenu 
	"Answer the menu for the categories pane."
	aMenu add: 'save' action: #save.
	aMenu balloonTextForLastItem: 'Save the database'.
	aMenu addLine.
	aMenu add: 'fetch mail' action: #fetchMail.
	aMenu balloonTextForLastItem: 'Fetch new mail from the server'.
	aMenu add: 'send queued mail' action: #sendQueuedMail.
	aMenu balloonTextForLastItem: 'Send newly written mail'.
	aMenu addLine.
	aMenu add: 'add category' action: #addCategory.
	aMenu balloonTextForLastItem: 'Add a new organizational category'.
	currentCategory notNil
		ifTrue: [aMenu add: 'view all messages' action: #viewAllMessages.
			aMenu balloonTextForLastItem: 'View all the messages'].
	"add extra commands if a normal category is selected"
	(currentCategory notNil
			and: [currentCategory ~= '.all.' & (currentCategory ~= '.unclassified.')])
		ifTrue: [aMenu add: 'edit category filter' action: #editCategoryFilter.
			aMenu balloonTextForLastItem: 'Edit a custom filter for this category'.
			aMenu add: 'rename category' action: #renameCategory.
			aMenu balloonTextForLastItem: 'Rename this organizational category'.
			aMenu add: 'remove category' action: #removeCategory.
			aMenu balloonTextForLastItem: 'Remove this organizational category
(NB: all messages will be safely available in other categories)'.
			aMenu addLine.
			aMenu add: 'import into category' action: #importIntoCategory.
			aMenu balloonTextForLastItem: 'Import messages from a Unix/Eudora file into this category'.
			aMenu add: 'export category (Celeste)' action: #exportCategory.
			aMenu balloonTextForLastItem: 'Copy all messages from this category to another Celeste database'.
			aMenu add: 'export category (Unix/Eudora)' action: #exportCategoryUnix.
			aMenu balloonTextForLastItem: 'Write a copy of all messages from this category to a Unix/Eudora file'].
	aMenu addLine.
	aMenu add: 'empty trash' action: #emptyTrash.
	aMenu balloonTextForLastItem: 'Completely remove all messages in the category .trash. from Celeste'.
	aMenu add: 'salvage & compact' action: #compact.
	aMenu balloonTextForLastItem: 'Salvage any work done since the last database save & recover space used by old deleted messages.
(This may be a bit slow)'.
	aMenu add: 'find duplicates' action: #findDuplicates.
	aMenu balloonTextForLastItem: 'Find messages which are exact duplicates'.
	aMenu addLine.
	aMenu addUpdating: #suppressingHeadersString action: #toggleSuppressHeaders.
	aMenu balloonTextForLastItem: 'Show either a complete or an easy-to-read message header'.
	aMenu add: 'change max current messages (' , self class messageCountLimit printString , ')' action: #changeMaxMessageCount.
	aMenu addLine.
	aMenu add: 'set user name' action: #setUserName.
	aMenu balloonTextForLastItem: 'Specify the ''From:'' user name for new messages'.
	aMenu add: 'set cc: list' action: #setCCList.
	aMenu balloonTextForLastItem: 'Specify a cc: list that is added to each new message'.
	aMenu add: 'set POP server' action: #setPopServer.
	aMenu balloonTextForLastItem: 'Specify which (POP3) server to check for new messages'.
	aMenu add: 'set POP username' action: #setPopUserName.
	aMenu balloonTextForLastItem: 'Specify the username to use when checking for new messages'.
	aMenu add: 'set SMTP server' action: #setSmtpServer.
	aMenu balloonTextForLastItem: 'Specify which (SMTP) server to use when sending messages'.
	aMenu addLine.
	aMenu addUpdating: #messagesOnServerString action: #toggleKeepMessagesOnServer.
	aMenu balloonTextForLastItem: 'When true, messages are not deleted from the server when you retreive them (typically used for testing only).  When false, messages are deleted from the server after you retreive them'.
	^ aMenu