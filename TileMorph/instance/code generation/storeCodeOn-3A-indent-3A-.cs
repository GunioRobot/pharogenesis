storeCodeOn: aStream indent: tabCount

	| op refType playerBearingCode |
	"Must determine whom is scripted for what follows to work"
	playerBearingCode _ self playerBearingCode.  "If it's ever nil, we've got trouble"
	type = #expression ifTrue:
		[^ aStream
			nextPut: $(;
			nextPutAll: operatorOrExpression;
			nextPut: $)].

	type = #literal ifTrue:
		[^ aStream
			nextPut: $(;
			nextPutAll: literal printString;
			nextPut: $)].

	type == #objRef ifTrue:
		[^ (playerBearingCode == actualObject)
			ifTrue:
				["This is the critical point -- if the object is the method's own 'self' then we MUST, rather than just MAY, put out self rather than the referencer call, though the latter will temporarily work as long we have true uniclasses."
				aStream nextPutAll: 'self']
			ifFalse:
				[aStream nextPutAll: 'self class '.
				aStream nextPutAll: (playerBearingCode class referenceSelectorFor: actualObject)]].

	type = #operator ifTrue:
		[((UpdatingOperators includesKey: operatorOrExpression) and:
		 [self precedingTileType = #slotRef])
			ifTrue: [op _ UpdatingOperators at: operatorOrExpression]
			ifFalse: [op _ operatorOrExpression].
		^ op isEmpty
			ifTrue: [aStream position: aStream position - 1]
			ifFalse: [aStream nextPutAll: op]].

"The following branch has long been disused
	type = #slotRef ifTrue:
		[self isThisEverCalled.
		refType _ self slotRefType.
		refType = #get ifTrue:
			[^ aStream
				nextPutAll: targetName;
				space;
				nextPutAll: (Utilities getterSelectorFor: slotName)].
		refType = #set ifTrue:
			[^ aStream
				nextPutAll: targetName;
				space;
				nextPutAll: (Utilities setterSelectorFor: slotName);
				nextPut: $:].
		refType = #update ifTrue:
			[^ aStream
				nextPutAll: targetName;
				space;
				nextPutAll: slotName;
				nextPutAll: ': ';
				nextPutAll: targetName;
				space;
				nextPutAll: slotName]]"
