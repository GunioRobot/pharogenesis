updatePreview
	"Update the preview after the selection has changed."

	| f |
	f _ visibleLayer form
		magnify: (selectionRect innerBounds translateBy: visibleLayer topLeft negated)
		by: 3.
	previewer image: f.
