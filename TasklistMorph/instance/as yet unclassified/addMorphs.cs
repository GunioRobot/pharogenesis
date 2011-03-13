addMorphs
	"Add our morphs."

	self preview: self newPreviewMorph.
	self taskList: self newTasksMorph.
	self addMorph: (
		(UITheme current newColumnIn: self for: {
			self preview.
			self taskList})
			vResizing: #shrinkWrap;
			cellInset: 8).
	self layoutChanged