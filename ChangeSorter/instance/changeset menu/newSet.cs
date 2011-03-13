newSet
	"Create a new changeSet and show it., making it the current one.  Reject name if already in use."

	| aSet |
	self okToChange ifFalse: [^ self].
	aSet := self class newChangeSet.
	aSet ifNotNil:
		[self changeSetCategory acceptsManualAdditions ifTrue:
			[changeSetCategory addChangeSet: aSet].
		self update.
		(changeSetCategory includesChangeSet: aSet) ifTrue:
			[self showChangeSet: aSet].
		self changed: #relabel]