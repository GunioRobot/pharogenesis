diff
	| ancestorVersion |
	self pickAncestor ifNotNilDo:
		[:ancestor |
		ancestorVersion _ self version workingCopy repositoryGroup versionWithInfo: ancestor.
		(version asDiffAgainst: ancestorVersion) open]