parseQueryResult: resultStream

	| projectInfos projectName  downloadUrl |
	projectInfos _ OrderedCollection new.
	downloadUrl _ self downloadUrl.
	resultStream reset; nextLine.
	[resultStream atEnd] whileFalse: [
		projectName _ resultStream nextLine.
		projectInfos add: projectName.
		"Transcript show: projectName; cr."
		].
	"Transcript show: 'done'; cr."
	^projectInfos
