addGeneralMenuOptionsTo: aMenu 
	"add menu items that have no other home to aMenu"

	aMenu add: 'save' action: #save.
	aMenu balloonTextForLastItem: 'Save the database'.
	aMenu add: 'new window' action: #spawnNewCeleste.
	aMenu balloonTextForLastItem: 'Open a new window on the same database'.

	aMenu addLine.
	aMenu add: 'fetch mail' action: #fetchMail.
	aMenu balloonTextForLastItem: 'Fetch new mail from the server'.
	aMenu add: 'send queued mail' action: #sendQueuedMail.
	aMenu balloonTextForLastItem: 'Send newly written mail'.
	aMenu addLine.
	aMenu add: 'add a new category' action: #addCategory.
	aMenu balloonTextForLastItem: 'Add a new organizational category'.	"add extra commands if a normal category is selected"
	(self category notNil 
		and: [self category ~= '.all.' & (self category ~= '.unclassified.')]) 
			ifTrue: 
				["this should either be modified to work with named filters, or chucked"

				"aMenu add: 'edit category filter' action: #editCategoryFilter.
			aMenu balloonTextForLastItem: 'Edit a custom filter for this category'."

				aMenu add: 'rename category ''' , self category , ''''
					action: #renameCategory.
				aMenu balloonTextForLastItem: 'Rename this organizational category'.
				aMenu add: 'remove category ''' , self category , ''''
					action: #removeCategory.
				aMenu 
					balloonTextForLastItem: 'Remove this organizational category
(NB: all messages will be safely available in other categories)'.
				aMenu addLine.
				aMenu add: 'import into ''' , self category , ''''
					action: #importIntoCategory.
				aMenu 
					balloonTextForLastItem: 'Import messages from a Unix/Eudora file into this category'].
	aMenu addLine.
	aMenu add: 'export (Celeste)' action: #exportCategory.
	aMenu 
		balloonTextForLastItem: 'Copy all selected messages to another Celeste database'.
	aMenu add: 'export (Unix/Eudora)' action: #exportCategoryUnix.
	aMenu 
		balloonTextForLastItem: 'Write a copy of all selected messages to a Unix/Eudora file'.
	aMenu addLine.
	aMenu add: 'empty trash' action: #emptyTrash.
	aMenu 
		balloonTextForLastItem: 'Completely remove all messages in the category .trash. from Celeste'.
	aMenu add: 'salvage & compact' action: #compact.
	aMenu 
		balloonTextForLastItem: 'Salvage any work done since the last database save & recover space used by old deleted messages.
(This may be a bit slow)'.
	aMenu add: 'find duplicates' action: #findDuplicates.
	aMenu balloonTextForLastItem: 'Find messages which are exact duplicates'.
	aMenu addLine.
	aMenu add: 'rebuild spam database' action: #rebuildSpamDatabase.
	aMenu balloonTextForLastItem: 'Rebuild the lists of tokens that Celeste uses to filter out unwanted e-mail'.
	aMenu addLine.
	aMenu 
		addUpdating: #showingRawMessageString
		action: #toggleSuppressHeaders
		default: self suppressingHeadersString.
	aMenu 
		balloonTextForLastItem: 'Show messages as they are on the wire; don''t format the message or trim the header.'.
	aMenu addLine.
	self account addCommandsTo: aMenu.
	aMenu addLine.
	aMenu add: 'save mail account settings' target: self selector: #writeSetup.
	aMenu add: 'read mail account settings' target: self selector: #readSetup.
	aMenu addLine.
	aMenu 
		addUpdating: #messagesOnServerString
		action: #toggleKeepMessagesOnServer
		default: self messagesOnServerString.
	aMenu 
		balloonTextForLastItem: 'When true, messages are not deleted from the server when you retreive them (typically used for testing only).  When false, messages are deleted from the server after you retreive them'.

	aMenu addLine.
	aMenu add: 'address book' action: #openAddressBook.
	aMenu
		addUpdating: #toggleUserInterfaceString
		action: #toggleUserInterface
		default: 'toggle basic/expert user interface'.
		
	^aMenu