informUser: aString during: aBlock
	"Display a message above (or below if insufficient room) the cursor during execution of the given block."
	"Utilities informUser: 'Just a sec!' during: [(Delay forSeconds: 1) wait]"

	Smalltalk isMorphic
		ifTrue:
			[(MVCMenuMorph from: (SelectionMenu labels: '') title: aString)
				displayAt: Sensor cursorPoint during: [aBlock value].
			^ self].

	(SelectionMenu labels: '')
		displayAt: Sensor cursorPoint
		withCaption: aString
		during: [aBlock value]