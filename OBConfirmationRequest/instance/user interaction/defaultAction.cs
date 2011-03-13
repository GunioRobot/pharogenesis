defaultAction
	(prompt beginsWith: 'BogusD') ifTrue: [self halt].
	^ PopUpMenu confirm: prompt trueChoice: confirm falseChoice: cancel