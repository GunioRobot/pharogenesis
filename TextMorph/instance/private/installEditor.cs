installEditor


	self flag: #bob.		"I don't see any senders (16 Feb 2001)"


	"Install an editor for my paragraph.  This constitutes 'hasFocus'."
	editor ifNotNil: [^ editor].
	^ self installEditorToReplace: nil