messageText: aText
	"change the current text"
	messageText _ aText squeakToIso.
	self changed: #messageText.
	^true