push: anAction
	"Pushes an undo action on the stack."

	(stackIsOpen) ifTrue: [ theStack addLast: anAction ].

	((theStack size) > maxStackDepth) ifTrue: [ theStack removeFirst ].
