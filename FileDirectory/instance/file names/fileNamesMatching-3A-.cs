fileNamesMatching: pat
	"FileDirectory default fileNamesMatching: '*'"
	^ self directoryContents
		collect: [:spec | spec first]
		thenSelect: [:fname | pat match: fname]