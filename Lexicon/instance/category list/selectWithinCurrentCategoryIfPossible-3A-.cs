selectWithinCurrentCategoryIfPossible: aSelector
	"If the receiver's message list contains aSelector, navigate right to it without changing categories"
 
	| detectedItem messageIndex |
	aSelector ifNil: [^ self].
	detectedItem _ messageList detect:
		[:anItem | (anItem asString upTo: $ ) asSymbol == aSelector] ifNone: [^ self].
	messageIndex _ messageList indexOf: detectedItem.
	self messageListIndex: messageIndex
