infoViewContents
	"Answer the string to show in the info view"

	| theClass stamp exists |
	editSelection == #newClass ifTrue: [^ self packageInfo: self selectedPackage].
	self selectedClass isNil ifTrue: [^ ''].
	theClass _ Smalltalk at: self selectedClass name asSymbol ifAbsent: [].
	editSelection == #editClass ifTrue:
		[^ theClass notNil
			ifTrue: ['Class exists already in the system' translated]
			ifFalse: ['New class' translated]].
	editSelection == #editMessage ifFalse: [^ ''].
	(theClass notNil and: [self metaClassIndicated])
		ifTrue: [theClass _ theClass class].

	stamp _ self selectedClassOrMetaClass stampAt: self selectedMessageName.
	exists _ theClass notNil and: [theClass includesSelector: self selectedMessageName].
	^ stamp = 'methodWasRemoved'
		ifTrue:
			[exists
				ifTrue:
					['Existing method removed  by this change-set' translated]
				ifFalse:
					['Removal request for a method that is not present in this image' translated]]
		ifFalse:
			[stamp, ' · ',
				(exists 
					ifTrue: ['Method already exists' translated , self extraInfo]
					ifFalse: ['New method' translated])]