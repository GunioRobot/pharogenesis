chooseCngSet
	"Put up a list of them"
	| index |
	ChangeSet instanceCount > AllChangeSets size ifTrue: [self gather].
	index _ (PopUpMenu labels: 
		(AllChangeSets collect: [:each | each name]) asStringWithCr) startUp.
	index = 0 ifFalse: [self showChangeSet: (AllChangeSets at: index)].