contactListMenu: aMenu
	"Dinamically  generated menu based on user selection. Must Be FAST!"
	
	| cab |
	cab _  selectedContact asString.
	selectedContact ~=nil ifTrue:[
		aMenu add: ('send a message to ', cab) action: #sendMessageToSelectedContact.
		aMenu balloonTextForLastItem: 'Send an email to that contact using default Celeste DB'.		
		aMenu add: ('More info on ', cab) action: #moreInfoOnSelectedContact.
		aMenu balloonTextForLastItem: ' Give you more information on that email (frequency and so on)'.

		aMenu addLine.

		aMenu add: 'explore it' action: #exploreSelectedContact.
		
	].

	aMenu add: 'remove all showed contacts' action: #removeFilteredContactMenuAction.
	aMenu balloonTextForLastItem: 'Destory all the showed contact. Danger'.

	aMenu add: 'Save to disk...' action: #saveToDiskMenuAction.
	aMenu balloonTextForLastItem: 'Save the contact list to a standard object file. Userful for backups.'.

	aMenu add: 'Load From disk...' action: #loadFromDiskMenuAction.
	aMenu balloonTextForLastItem: 'Load the contact list from a standard object file.'.	

	selectedContact ~=nil ifTrue:[
		aMenu addLine.
		aMenu add: 'remove this contact:',  (selectedContact asString) action: #removeSelectedContactMenuAction.
		aMenu balloonTextForLastItem: 'Remove selected contact'.
	].

	^aMenu.
	
