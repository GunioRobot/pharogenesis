setChangeSet: aChangeSet

	isolatedHead == true ifTrue: [^ self].  "ChangeSet of an isolated project cannot be changed"
	changeSet := aChangeSet
