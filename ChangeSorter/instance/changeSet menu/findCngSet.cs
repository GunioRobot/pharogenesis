findCngSet 
	"Search for a changeSet by name.  Pop up a menu of all changeSets whose name contains the string entered by the user.  If only one matches, then the pop-up menu is bypassed"
	| index pattern candidates |
	self okToChange ifFalse: [^ self].
	ChangeSet instanceCount > AllChangeSets size ifTrue: [self class gatherChangeSets].
	pattern _ FillInTheBlank request: 'ChangeSet name or fragment?'.
	pattern isEmpty ifTrue: [^ self].
	candidates _ AllChangeSets select:
			[:c | c name includesSubstring: pattern caseSensitive: false].
	candidates size = 0 ifTrue: [^ self beep].
	candidates size = 1 ifTrue:
		[^ self showChangeSet: candidates first].
	index _ (PopUpMenu labels: 
		(candidates collect: [:each | each name]) asStringWithCr) startUp.
	index = 0 ifFalse: [self showChangeSet: (candidates at: index)].
