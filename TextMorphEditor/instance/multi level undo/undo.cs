undo
	"Reset the state of the paragraph prior to the previous edit.
	 If another ParagraphEditor instance did that edit, UndoInterval is invalid;
	 just recover the contents of the undo-buffer at the start of the paragraph."

	Preferences multipleTextUndo 
		ifTrue: [ ^self multiUndo ]
		ifFalse:[ ^super undo ].
