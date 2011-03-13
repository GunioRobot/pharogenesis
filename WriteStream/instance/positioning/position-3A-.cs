position: anInteger 
	"Refer to the comment in PositionableStream|position:."

	readLimit _ readLimit max: position.
	super position: anInteger