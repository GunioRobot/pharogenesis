setDestForm: df
	| bb |
	bb _ df boundingBox.
	destForm _ df.
	clipX _ bb left.
	clipY _ bb top.
	clipWidth _ bb width.
	clipHeight _ bb height