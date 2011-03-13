bounds: newBounds

	selectedItems _ OrderedCollection new.  "Avoid repostioning items during super position:"
	super bounds: newBounds