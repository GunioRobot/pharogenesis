removeRemoteClient: aClient
	self removeHand: aClient hand.
	worldState removeRemoteCanvas: aClient canvas.
	self changed.  "force a redraw"
