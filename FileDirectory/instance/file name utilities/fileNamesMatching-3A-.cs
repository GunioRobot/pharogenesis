fileNamesMatching: pat
	"FileDirectory default fileNamesMatching: '*'"

	^ self fileNames select: [:name | pat match: name]
