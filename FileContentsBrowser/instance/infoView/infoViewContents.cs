infoViewContents
	| theClass |
	editSelection == #newClass ifTrue: [^ self packageInfo: self selectedPackage].
	self selectedClass isNil ifTrue: [^ ''].
	theClass _ Smalltalk at: self selectedClass name asSymbol ifAbsent: [].
	editSelection == #editClass ifTrue: [^ theClass notNil
			ifTrue: ['Class exists already in the system']
			ifFalse: ['New class']].
	editSelection == #editMessage ifFalse: [^ ''].
	(theClass notNil and: [self metaClassIndicated])
		ifTrue: [theClass _ theClass class].
	^ (theClass notNil and: [theClass includesSelector: self selectedMessageName])
		ifTrue: ['Method already exists' , self extraInfo]
		ifFalse: ['New method']