undoIt
	"Undo the show or hide event"

	(undoingHide) 	ifTrue: [ theActor setHidden: false ]
					ifFalse: [ theActor setHidden: true ].
