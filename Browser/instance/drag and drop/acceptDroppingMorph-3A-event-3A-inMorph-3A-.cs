acceptDroppingMorph: transferMorph event: evt inMorph: dstListMorph 
	"Here we are fetching informations from the dropped transferMorph and 
	             performing the correct action for this drop."

	| srcType success srcBrowser |
	success _ false.
	srcType _ transferMorph dragTransferType.
	srcBrowser _ transferMorph source model.
	srcType == #messageList ifTrue: [success _ self
					acceptMethod: transferMorph passenger value
					messageCategory: srcBrowser selectedMessageCategoryName
					class: transferMorph passenger key
					atListMorph: dstListMorph
					internal: self == srcBrowser
					copy: transferMorph shouldCopy].
	srcType == #classList
		ifTrue: 
			[success _ self
				changeCategoryForClass: transferMorph passenger
				srcSystemCategory: srcBrowser selectedSystemCategoryName
				atListMorph: dstListMorph
				internal: self == srcBrowser
				copy: transferMorph shouldCopy].
	^success