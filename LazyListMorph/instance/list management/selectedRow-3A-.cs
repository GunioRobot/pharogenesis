selectedRow: index
	"select the index-th row.  if nil, remove the current selection"
	selectedRow := index.
	self changed.