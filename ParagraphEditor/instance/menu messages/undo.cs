undo
	"Reset the state of the paragraph prior to the previous edit.
	 If another ParagraphEditor instance did that edit, UndoInterval is invalid;
	 just recover the contents of the undo-buffer at the start of the paragraph."

	Sensor flushKeyboard. "a way to flush stuck keys"
	self closeTypeIn.

	UndoParagraph == paragraph ifFalse: "Can't undo another paragraph's edit"
		[UndoMessage := Message selector: #undoReplace.
		UndoInterval := 1 to: 0.
		Undone := true].
	UndoInterval ~= self selectionInterval ifTrue: "blink the actual target"
		[self selectInterval: UndoInterval; deselect].

	"Leave a signal of which phase is in progress"
	UndoParagraph := Undone ifTrue: [#redoing] ifFalse: [#undoing].
	UndoMessage sentTo: self.
	UndoParagraph := paragraph