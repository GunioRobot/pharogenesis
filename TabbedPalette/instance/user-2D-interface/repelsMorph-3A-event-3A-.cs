repelsMorph: aMorph event: ev
	true ifTrue: [^ super repelsMorph: aMorph event: ev].
	self visible ifFalse: [^ false].
	^self dragNDropEnabled not