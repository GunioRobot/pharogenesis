setSendersSearch
	"Put up a list of messages sent in the current message, find all methods 
	of the browsee which send the one the user chooses, and show that list 
	in the message-list pane, with the 'query results' item selected in the 
	category-list pane"
	| selectorSet aSelector aString |
	self selectedMessageName
		ifNil: [aString := UIManager default request: 'Type selector to search for' initialAnswer: 'flag:'.
			aString isEmptyOrNil
				ifTrue: [^ self].
			Symbol
				hasInterned: aString
				ifTrue: [:sel | aSelector := sel]]
		ifNotNil: [self
				selectMessageAndEvaluate: [:sel | aSelector := sel]].
	aSelector
		ifNil: [^ self].
	selectorSet := Set new.
	(self systemNavigation allCallsOn: aSelector)
		do: [:anItem | selectorSet add: anItem methodSymbol].
	selectorSet := selectorSet
				select: [:sel | currentVocabulary
						includesSelector: sel
						forInstance: self targetObject
						ofClass: targetClass
						limitClass: limitClass].
	selectorSet size > 0
		ifTrue: [currentQuery := #senders.
			currentQueryParameter := aSelector.
			self
				categoryListIndex: (categoryList indexOf: self class queryCategoryName).
			self messageListIndex: 0]