translateReachableSelfSenders: senderCollection translations: translationDictionary
	| result superSenders |
	(translationDictionary isEmptyOrNil or: [senderCollection isEmpty]) ifTrue: [^ senderCollection].
	result := FixedIdentitySet new.
	senderCollection do: [:s |
		superSenders := translationDictionary at: s ifAbsent: [nil].
		superSenders isNil
			ifTrue: [result add: s]
			ifFalse: [result addAll: superSenders].
		result isFull ifTrue: [^ result].
	].
	^ result.