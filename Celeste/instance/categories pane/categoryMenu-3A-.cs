categoryMenu: aMenu 
	"Answer the menu for the categories pane."
	| labels lineSeparations selectors lines |
	labels _ 'save\fetch mail\send queued mail\add category' withCRs.
	lineSeparations _ #(1 2 1 ).
	selectors _ #(#save #fetchMail #sendQueuedMail #addCategory ).
	"add commands if any category is selected."
	currentCategory notNil
		ifTrue: 
			[labels _ labels , '\view all messages' withCRs.
			selectors _ selectors , #(#viewAllMessages ).
	"add extra commands if a normal category is selected"
	(currentCategory ~= '.all.' & (currentCategory ~= '.unclassified.'))
		ifTrue: 
			[labels _ labels , '\edit category filter\rename category\remove category\import into category\export category (Celeste)\export category (Unix/Eudora)' withCRs.
			lineSeparations _ lineSeparations , #(4 3 ).
			selectors _ selectors , #(#editCategoryFilter #renameCategory #removeCategory #importIntoCategory #exportCategory #exportCategoryUnix )]
		ifFalse: [lineSeparations _ lineSeparations , #(1 )]].
	labels _ labels , '\empty trash\compact\find duplicates\toggle headers\set user name\set cc: list\set POP server\set POP username\set SMTP server' withCRs.
	lineSeparations _ lineSeparations , #(3 1 5 ).
	selectors _ selectors , #(#emptyTrash #compact #findDuplicates #toggleSuppressHeaders #setUserName #setCCList #setPopServer #setPopUserName #setSmtpServer ).
	"add toggle for whether to delete messages on download"
	DeleteInboxAfterFetching
		ifTrue: 
			[labels _ labels , '\leave messages on server' withCRs.
			selectors _ selectors , #(#keepMessagesOnServer )]
		ifFalse: 
			[labels _ labels , '\don''t leave messages on server' withCRs.
			selectors _ selectors , #(#deleteMessagesAfterFetching )].
	lineSeparations _ lineSeparations , #(1 ).
	"convert lineSeperations into absolute line positions"
	lines _ lineSeparations copyFrom: 1 to: lineSeparations size - 1.
	(2 to: lines size)
		do: [:i | lines at: i put: (lines at: i)
					+ (lines at: i - 1)].
	^ aMenu
		labels: labels
		lines: lines
		selections: selectors