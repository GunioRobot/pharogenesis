editDrawing
	self flag: #deferred.  "Don't allow this if the user is already in paint mode, because it creates a very strange situation."
	self editDrawingIn: self pasteUpMorph forBackground: false
