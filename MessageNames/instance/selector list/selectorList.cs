selectorList
	"Answer the selectorList"

	selectorList ifNil:
		[self computeSelectorListFromSearchString.
		selectorListIndex _  selectorList size > 0
			ifTrue:	[1]
			ifFalse: [0].
		messageList _ nil].
	^ selectorList