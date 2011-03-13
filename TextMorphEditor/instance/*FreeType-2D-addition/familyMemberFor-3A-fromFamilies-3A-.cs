familyMemberFor: aFont fromFamilies: aCollection
	| family weightValue slantValue stretchValue |
	family := aCollection detect:[:each | each familyName = aFont familyName] ifNone:[].
	family ifNil:[^nil].
	(aFont isKindOf: LogicalFont)
		ifTrue:[
			weightValue := aFont weightValue.
			slantValue := aFont slantValue.
			stretchValue := aFont stretchValue]
		ifFalse:[
			weightValue := (aFont emphasis bitAnd: 1) > 0 ifTrue:[700] ifFalse:[400].
			slantValue := (aFont emphasis bitAnd: 2) > 0 ifTrue:[1] ifFalse:[0].
			stretchValue := 5 "normal"].		
	^family closestMemberWithStretchValue: stretchValue weightValue: weightValue slantValue: slantValue	
	