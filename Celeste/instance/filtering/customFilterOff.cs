customFilterOff
	"Cancel custom filtering."

	customFilterBlock ifNil: [
		"it's already turned off"
		^self ].

	customFilterBlock _ nil.
	self updateTOC.
	self changed: #isCustomFilterOn.