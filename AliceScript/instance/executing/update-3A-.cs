update: currentTime
	"Determine how to update this script based on the type of script it is"

	(scriptType = inOrder)
		ifTrue: [ self updateInOrder: currentTime ]
		ifFalse: [ self updateTogether: currentTime ].

