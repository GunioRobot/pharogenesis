sourceDirectory
	| fd |
	fd _ FileDirectory default directoryNamed: (sourceDirName
		ifNil: [self class sourceDirName]).
	fd assureExistence.
	^ fd