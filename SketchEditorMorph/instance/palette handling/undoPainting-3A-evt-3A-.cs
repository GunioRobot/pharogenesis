undoPainting: aPaintBoxMorph evt: evt
	"Undo the operation after user issued #undo in aPaintBoxMorph"
	^self undo: evt