chooseCngSet
	"Put up a list of them"
	| index |

	self okToChange ifFalse: [^ self].
	ChangeSet instanceCount > AllChangeSets size ifTrue: [self class gatherChangeSets].
	index _ (PopUpMenu labels: 
		(AllChangeSets collect: [:each | each name]) asStringWithCr) startUp.
	index = 0 ifFalse: [self showChangeSet: (AllChangeSets at: index)].