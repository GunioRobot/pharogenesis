chooseFilterFor: msgID from: filterNames
	| res |
	res _ self filtersFor: msgID from: filterNames.
	res isEmpty ifTrue:[^nil].
	res size = 1 ifTrue: [^res anyOne].
	^self selectFilterFrom: res 