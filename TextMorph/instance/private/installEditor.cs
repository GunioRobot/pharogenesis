installEditor
	"Install an editor for my paragraph.  This constitutes 'hasFocus'."
	editor ifNotNil: [^ editor].
	editor _ TextMorphEditor new morph: self.
	editor changeParagraph: self paragraph.
	self selectionChanged.
	^ editor