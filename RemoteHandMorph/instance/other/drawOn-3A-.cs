drawOn: aCanvas
	"For remote cursors, always draw the hand itself (i.e., the cursor)."

	super drawOn: aCanvas.
	aCanvas image: NormalCursor at: self position.
