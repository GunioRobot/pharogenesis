viewByName
	"Make the receiver show its subparts as a vertical list of lines of information, sorted by object name"

	self imposeListViewSortingBy: #downshiftedNameOfObjectRepresented retrieving: #(nameOfObjectRepresented reportableSize  className oopString)