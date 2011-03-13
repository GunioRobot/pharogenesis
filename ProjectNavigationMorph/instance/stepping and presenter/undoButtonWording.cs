undoButtonWording
	"Answer the wording for the Undo button."

	| wdng |
	wdng _ ActiveWorld commandHistory undoOrRedoMenuWording.
	(wdng endsWith: ' (z)') ifTrue:
		[wdng _ wdng copyFrom: 1to: wdng size - 4].
	^ wdng