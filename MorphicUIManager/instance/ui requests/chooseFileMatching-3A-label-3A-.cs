chooseFileMatching: patterns label: aString
	"Let the user choose a file matching the given patterns"
	| result |
	result := FileList modalFileSelectorForSuffixes: patterns.
	^result ifNotNil:[result fullName]