icon
	"Answer a form with an icon to represent the receiver"
	
	self conflict ifNotNilDo: [:c |
		c localChosen ifTrue: [^MenuIcons smallBackIcon]].
	^super icon