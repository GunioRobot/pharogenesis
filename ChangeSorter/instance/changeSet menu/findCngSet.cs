findCngSet 
	"Search for a changeSet by name.  Pop up a menu of all changeSets whose name contains the string entered by the user.  If only one matches, then the pop-up menu is bypassed"
	| index pattern candidates nameList |
	self okToChange ifFalse: [^ self].
	pattern _ FillInTheBlank request: 'ChangeSet name or fragment?'.
	pattern isEmpty ifTrue: [^ self].
	nameList _ self changeSetList asSet.
	candidates _ AllChangeSets select:
			[:c | (nameList includes: c name) and: 
				[c name includesSubstring: pattern caseSensitive: false]].
	candidates size = 0 ifTrue: [^ Beeper beep].
	candidates size = 1 ifTrue:
		[^ self showChangeSet: candidates first].
	index _ (PopUpMenu labels: 
		(candidates collect: [:each | each name]) asStringWithCr) startUp.
	index = 0 ifFalse: [self showChangeSet: (candidates at: index)].
