editSelection: aSelection
	"Set the editSelection as requested."

	editSelection _ aSelection.
	self changed: #editSelection.