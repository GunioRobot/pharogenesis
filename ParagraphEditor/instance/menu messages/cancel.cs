cancel 
	"Restore the text of the paragraph to be the text saved since initialization 
	or the last accept.  Undoer & Redoer: undoAndReselect:redoAndReselect:.
	This used to call controlTerminate and controlInitialize but this seemed illogical.
	Sure enough, nobody overrode them who had cancel in the menu, and if
	anybody really cared they could override cancel."

	UndoSelection := paragraph text.
	self undoer: #undoAndReselect:redoAndReselect: with: self selectionInterval with: (1 to: 0).
	self changeParagraph: (paragraph text: initialText).
	UndoParagraph := paragraph.
	otherInterval := UndoInterval := 1 to: initialText size. "so undo will replace all"
	paragraph displayOn: Display.
	self selectAt: 1.
	self scrollToTop
