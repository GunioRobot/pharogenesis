installEditor
	"Install an editor for my paragraph.  This constitutes 'hasFocus'."
	editor ifNotNil: [^ editor].
	^ self installEditorToReplace: nil