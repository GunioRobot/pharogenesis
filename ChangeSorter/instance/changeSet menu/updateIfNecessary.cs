updateIfNecessary
	"recompute all of my panes"
	| newList |
	myChangeSet isMoribund ifTrue:
		[^ self showChangeSet: Smalltalk changes].

	self okToChange ifFalse: [^ self].
	priorChangeSetList == nil
		ifTrue: [priorChangeSetList _ self changeSetList.
				self changed: #changeSetList]
		ifFalse: [newList _ self changeSetList.
				priorChangeSetList = newList ifFalse:
					[priorChangeSetList _ newList.
					self changed: #changeSetList]].
	self showChangeSet: myChangeSet