selectWithinCurrentCategory: aSelector
	"If aSelector is one of the selectors seen in the current category, select it"

	| detectedItem |
	detectedItem _ self messageList detect:
		[:anItem | (anItem asString upTo: $ ) asSymbol == aSelector] ifNone: [^ self].
	self messageListIndex:  (messageList indexOf: detectedItem ifAbsent: [^ self])