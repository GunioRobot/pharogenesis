setChangeSet: aChangeSet

	isolatedHead ifTrue: [^ self].  "ChangeSet of an isolated project cannot be changed"
	changeSet _ aChangeSet
