selectRow: index
	"select the index-th row"
	selectedRows add: index.
	self changed.