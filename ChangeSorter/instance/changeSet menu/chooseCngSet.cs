chooseCngSet
	"Present the user with an alphabetical list of change set names, and let her choose one"
	| index changeSetsSortedAlphabetically |
	self okToChange ifFalse: [^ self].
	ChangeSet instanceCount > AllChangeSets size ifTrue: [self class gatherChangeSets].
	changeSetsSortedAlphabetically _ AllChangeSets asSortedCollection:
		[:a :b | a name asLowercase withoutLeadingDigits < b name asLowercase withoutLeadingDigits].

	index _ (PopUpMenu labels: Smalltalk changes name , ' (active)' , Character cr asString ,
				(changeSetsSortedAlphabetically collect: [:each | each name]) asStringWithCr)
			startUp.
	index = 0 ifTrue: [^ self].
	index = 1 ifTrue: [^ self showChangeSet: Smalltalk changes].
	self showChangeSet: (changeSetsSortedAlphabetically at: index-1).
