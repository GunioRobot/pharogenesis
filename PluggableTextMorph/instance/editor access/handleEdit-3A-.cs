handleEdit: editBlock
	textMorph editor model: model.  "For evaluateSelection"
	textMorph handleEdit: editBlock.   "Update selection after edit"
	self scrollSelectionIntoView