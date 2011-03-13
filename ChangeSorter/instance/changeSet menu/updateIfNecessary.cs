updateIfNecessary
	"Recompute all of my panes."

	| newList |
	self okToChange ifFalse: [^ self].
	myChangeSet isMoribund ifTrue: [^ self showChangeSet: Smalltalk changes].
	newList _ self changeSetList.
	(priorChangeSetList == nil or: [priorChangeSetList ~= newList])
		ifTrue:
			[priorChangeSetList _ newList.
			self changed: #changeSetList].
	self showChangeSet: myChangeSet