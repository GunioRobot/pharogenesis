removeLastCharFromPresentation

	presentation ifNotNil: [
		presentation position: presentation position - 1.
	].
	destX := destX - lastWidth.
