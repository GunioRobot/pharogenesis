addTileHandle: haloSpec
	self addHandle: haloSpec on: #mouseDown send: #tearOffTile to: innerTarget
