containsPoint: aPoint
	| localPt |
	(self bounds containsPoint: aPoint) ifFalse:[^false].
	localPt := self transform globalPointToLocal: aPoint.
	submorphs do:[:m| 
		((m valueOfProperty: #sensitive) ifNil:[false]) ifTrue:[
			(m bounds containsPoint: localPt) ifTrue:[^true].
		].
	].
	^false