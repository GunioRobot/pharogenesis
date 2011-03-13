translateReachableSelfSenders: senderCollection translations: translationDictionary
	| result superSenders |
	(translationDictionary isEmptyOrNil or: [senderCollection isEmpty]) ifTrue: [^ senderCollection].
	result _ FixedIdentitySet new.
	senderCollection do: [:s |
		superSenders _ translationDictionary at: s ifAbsent: [nil].
		superSenders isNil
			ifTrue: [result add: s]
			ifFalse: [result addAll: superSenders].
		result isFull ifTrue: [^ result].
	].
	^ result.