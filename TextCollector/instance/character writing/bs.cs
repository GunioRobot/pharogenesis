bs
	"Backspace the Transcript.  Put in at Alan's request 1/31/96 sw"
	"Transcript bs"

	contents _ contents copyFrom: 1 to: contents size - 1.
	self changed: #update