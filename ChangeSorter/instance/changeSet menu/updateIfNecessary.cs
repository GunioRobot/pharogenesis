updateIfNecessary
	"Recompute all of my panes."

	| newList |
	self okToChange ifFalse: [^ self].

	myChangeSet ifNil: [^ self].  "Has been known to happen though shouldn't"
	(myChangeSet isMoribund or: [(changeSetCategory notNil and: [changeSetCategory includesChangeSet: myChangeSet]) not]) ifTrue:
		[self changed: #changeSetList.
		^ self showChangeSet: self changeSetCategory defaultChangeSetToShow].

	newList _ self changeSetList.

	(priorChangeSetList == nil or: [priorChangeSetList ~= newList])
		ifTrue:
			[priorChangeSetList _ newList.
			self changed: #changeSetList].
	self showChangeSet: myChangeSet