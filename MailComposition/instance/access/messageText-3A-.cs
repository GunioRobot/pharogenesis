messageText: aText
	"change the current text"
	messageText _ aText.
	self changed: #messageText.
	^true