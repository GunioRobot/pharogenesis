parseROUTE: aVRMLStream
	| fromNode outEvent toNode inEvent |
	aVRMLStream skipSeparators.
	fromNode := aVRMLStream readName.
	aVRMLStream next = $. ifFalse:[^self error:'Period expected'].
	outEvent := aVRMLStream readName.
	aVRMLStream skipSeparators.
	aVRMLStream readName = 'TO' ifFalse:[^self error:'TO expected'].
	aVRMLStream skipSeparators.
	toNode := aVRMLStream readName.
	aVRMLStream next = $. ifFalse:[^self error:'Period expected'].
	inEvent := aVRMLStream readName.
	scene routeFrom: fromNode event: outEvent to: toNode event: inEvent.
	^nil