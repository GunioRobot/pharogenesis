seeAlso: aSelector
	"If the requested selector is showable in the current browser, show it here, minding unsubmitted edits however"

	((currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: targetClass limitClass: limitClass)   "i.e., is aSelector available in this browser"
					and: [self okToChange])
		ifTrue:
			[self displaySelector: aSelector]
		ifFalse:
			[Beeper beep]