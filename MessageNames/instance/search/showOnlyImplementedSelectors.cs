showOnlyImplementedSelectors
	"Caution -- can be slow! Filter my selector list down such that it only  
	shows selectors that are actually implemented somewhere in the system."
	self okToChange
		ifTrue: [Cursor wait
				showWhile: [selectorList _ self systemNavigation allSelectorsWithAnyImplementorsIn: selectorList.
					self changed: #selectorList.
					self changed: #messageList]]