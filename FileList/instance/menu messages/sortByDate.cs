sortByDate
	"Resort the list of files"
	sortMode _ #date.
	self newListAndPattern:
		(pattern == nil ifTrue: ['*'] ifFalse: [pattern])