prepareToDeactivate
	"Call this when about to open another MVC window summarily, to obscure the Morphic cursors.  "

	hands do:
		[:h | h showTemporaryCursor: Cursor blank].
	self displayWorld.
	hands do:
		[:h | h showTemporaryCursor: Cursor normal]