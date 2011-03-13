sortBySize
	"Resort the list of files"
	sortMode _ #size.
	self newListAndPattern:
		(pattern == nil ifTrue: ['*'] ifFalse: [pattern])