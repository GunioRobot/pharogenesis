selectSelectorItsNaturalCategory: aSelector
	"Make aSelector be the current selection of the receiver, with the category being its home category."

	| cat catIndex detectedItem |
	cat _ self categoryOfSelector: aSelector.
	catIndex _ categoryList indexOf: cat ifAbsent:
		["The method's own category is not seen in this browser; the method probably occurs in some other category not known directly to the class, but for now, we'll just use the all category"
		1].
	self categoryListIndex: catIndex.
	detectedItem _ messageList detect:
		[:anItem | (anItem asString upTo: $ ) asSymbol == aSelector] ifNone: [^ self].
	self messageListIndex:  (messageList indexOf: detectedItem ifAbsent: [^ self])