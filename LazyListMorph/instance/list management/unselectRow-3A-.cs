unselectRow: index
	"unselect the index-th row"
	selectedRows remove: index ifAbsent: [].
	self changed.