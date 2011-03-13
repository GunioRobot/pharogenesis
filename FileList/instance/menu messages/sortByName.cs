sortByName
	"Resort the list of files"
	sortMode _ #name.
	self newListAndPattern:
		(pattern == nil ifTrue: ['*'] ifFalse: [pattern])