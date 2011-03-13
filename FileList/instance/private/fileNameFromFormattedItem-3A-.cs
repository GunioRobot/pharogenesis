fileNameFromFormattedItem: item
	"Extract fileName and folderString from a formatted fileList item string"
	item first = $(   "remove size and date"
		ifTrue: [^ item copyFrom: (item indexOf: $)) + 2 to: item size]
		ifFalse: [^ item copyFrom: 1 to: (item findLast: [:c | c = $(])-5]