textEditorView
	"Return the first view in the receiver whose controller is a ParagraphEdior, or nil if none.  1/31/96 sw"

	(controller isKindOf: ParagraphEditor) ifTrue: [^ self].
	^ self subViewSatisfying:
		[:v | v textEditorView ~~ nil]