pause

	gameOver ifTrue: [^ self].
	paused _ paused not.
