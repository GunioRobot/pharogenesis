fileNameFromFormattedItem: item
	"Extract fileName and folderString from a formatted fileList item string"
	| i |
	(i _ item indexOf: $( ifAbsent: [0]) = 0 ifTrue: [^ item withBlanksTrimmed].
	^ (item copyReplaceFrom: i to: (item findFirst: [:c | c = $)]) with: '') withBlanksTrimmed