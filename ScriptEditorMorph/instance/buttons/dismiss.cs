dismiss
	| aMenu reply |
	owner ifNil: [^ self].
	scriptName ifNil: [^ self delete].  "ad hoc fixup for bkwrd compat"
	self isAnonymous
		ifTrue:
			[((submorphs size > 3) or: [self scriptInstantiation status ~~ #normal]) ifTrue:
				[aMenu _ SelectionMenu selections: #('yes, name it' 'no, discard it' 'cancel').
				reply _ aMenu startUpWithCaption: 'Do you want to give this
script a name and save it? '.
				(reply isEmptyOrNil or: [reply = 'cancel']) ifTrue: [^ self].
				(reply = 'yes, name it') ifTrue: [^ self renameScript]].
		self actuallyDestroyScript].
	(playerScripted isExpendableScript: scriptName) ifTrue: [playerScripted removeScript: scriptName].
	self delete