navigateToASender
	"Present the user with a list of senders of the currently-selected 
	message, and navigate to the chosen one"
	| selectorSet chosen aSelector |
	aSelector _ self selectedMessageName.
	selectorSet _ Set new.
	(self systemNavigation allCallsOn: aSelector)
		do: [:anItem | selectorSet add: anItem methodSymbol].
	selectorSet _ selectorSet
				select: [:sel | currentVocabulary
						includesSelector: sel
						forInstance: self targetObject
						ofClass: targetClass
						limitClass: limitClass].
	selectorSet size == 0
		ifTrue: [^ Beeper beep].
	self okToChange
		ifFalse: [^ self].
	chosen _ (SelectionMenu selections: selectorSet asSortedArray) startUp.
	chosen isEmptyOrNil
		ifFalse: [self displaySelector: chosen]