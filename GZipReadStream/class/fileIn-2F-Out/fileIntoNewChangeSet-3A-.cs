fileIntoNewChangeSet: fullFileName
	"FileIn the contents of a gzipped file"
	| zipped unzipped cs |
	cs _ Smalltalk at: #ChangeSorter ifAbsent: [ ^self ].
	zipped _ self on: (FileStream readOnlyFileNamed: fullFileName).
	unzipped _ MultiByteBinaryOrTextStream with: zipped contents asString.
	unzipped reset.
	cs newChangesFromStream: unzipped named: (FileDirectory localNameFor: fullFileName)
