displaySelector: aSelector
	"Set aSelector to be the one whose source shows in the browser.  If there is a category list, make it highlight a suitable category"

	| detectedItem messageIndex |
	self chooseCategory: (self categoryDefiningSelector: aSelector).
	detectedItem _ messageList detect:
		[:anItem | (anItem asString upTo: $ ) asSymbol == aSelector] ifNone: [^ Beeper beep].
	messageIndex _ messageList indexOf: detectedItem.
	self messageListIndex: messageIndex