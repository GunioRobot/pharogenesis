saveVersion
	workingCopy newVersion ifNotNilDo:
		[:v |
		(MCVersionInspector new version: v) show.
		Cursor wait showWhile: [self repository storeVersion: v].
		v allAvailableDependenciesDo:
			[:dep |
			(self repository includesVersionNamed: dep info name)
				ifFalse: [self repository storeVersion: dep]]]
