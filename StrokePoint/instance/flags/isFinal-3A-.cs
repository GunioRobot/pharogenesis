isFinal: aBool
	flags _ aBool ifTrue:[flags bitOr: 1] ifFalse:[flags bitClear: 1].
	(aBool and:[prev notNil and:[prev isFinal not]]) ifTrue:[prev isFinal: true].