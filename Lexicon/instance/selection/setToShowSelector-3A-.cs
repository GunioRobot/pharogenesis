setToShowSelector: aSelector
	"Set up the receiver so that it will show the given selector"

	| catName catIndex detectedItem messageIndex aList |
	catName := (aList := currentVocabulary categoriesContaining: aSelector  forClass: targetClass) size > 0
		ifTrue:
			[aList first]
		ifFalse:
			[self class allCategoryName].
	catIndex := categoryList indexOf: catName ifAbsent: [1].
	self categoryListIndex: catIndex.
	detectedItem := messageList detect:
		[:anItem | (anItem upTo: $ ) asString asSymbol == aSelector] ifNone: [^ self].
	messageIndex := messageList indexOf: detectedItem.
	self messageListIndex: messageIndex
