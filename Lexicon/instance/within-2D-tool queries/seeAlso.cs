seeAlso
	"Present a menu offering the selector of the currently selected message, as well as of all messages sent by it.  If the chosen selector is showable in the current browser, show it here, minding unsubmitted edits however"

	self selectImplementedMessageAndEvaluate:
		[:aSelector |
			((currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: targetClass limitClass: limitClass)  			 "i.e., is this aSelector available in this browser"
					and: [self okToChange])
				ifTrue:
					[self displaySelector: aSelector]
				ifFalse:
					[Beeper beep.  "SysttemNavigation new browseAllImplementorsOf: aSelector"]].
					"Initially I tried making this open an external implementors browser in this case, but later decided that the user model for this was unstable"