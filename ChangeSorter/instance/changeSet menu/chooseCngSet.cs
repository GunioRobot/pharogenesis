chooseCngSet
	"Present the user with an alphabetical list of change set names, and let her choose one"
	| index changeSetsSortedAlphabetically |
	self okToChange ifFalse: [^ self].
	ChangeSet instanceCount > AllChangeSets size ifTrue: [self class gatherChangeSets].
	changeSetsSortedAlphabetically _ AllChangeSets asSortedCollection:
		[:a :b | a name asLowercase withoutLeadingDigits < b name asLowercase withoutLeadingDigits].

	index _ (PopUpMenu labels: 
		(changeSetsSortedAlphabetically collect: [:each | each name]) asStringWithCr) startUp.
	index = 0 ifFalse: [self showChangeSet: (changeSetsSortedAlphabetically at: index)].
