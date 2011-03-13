purgeAllCommandsSuchThat: cmdBlock
	"Remove a bunch of commands, as in [:cmd | cmd undoTarget == zort]"

	Preferences useUndo ifFalse: [^ self].
	history _ history reject: cmdBlock.
	history isEmpty
		ifTrue: [lastCommand _ nil]
		ifFalse: [lastCommand _ history last]