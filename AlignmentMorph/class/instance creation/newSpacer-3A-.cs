newSpacer: aColor
	"Answer a space-filling instance of me of the given color."

	^ self new
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		inset: 0;
		borderWidth: 0;
		color: aColor.
