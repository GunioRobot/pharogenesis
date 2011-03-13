msgListIndex: anInteger
	"A selection has been made in the message pane"

	msgListIndex _ anInteger.
	self changed: #msgText.