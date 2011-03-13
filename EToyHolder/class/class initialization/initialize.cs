initialize
	"EToyHolder initialize"

	| ok |
	ok _ true.
	"UserStuffBook ~~ nil ifTrue:
		[ok _ self confirm: 'Are you sure you want to clear the user''s parts book?']."
	ok ifTrue: [UserStuffBook _ BookMorph new openToDragNDrop: true].
