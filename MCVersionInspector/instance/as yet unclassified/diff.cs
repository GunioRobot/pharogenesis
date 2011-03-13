diff
	| ancestorVersion |
	self pickAncestor ifNotNilDo:
		[:ancestor |
		ancestorVersion := self version workingCopy repositoryGroup versionWithInfo: ancestor.
		(self version asDiffAgainst: ancestorVersion) open]