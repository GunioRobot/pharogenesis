viewBySize
	"Make the receiver show its subparts as a vertical list of lines of information, sorted by object size"

	self imposeListViewSortingBy: #reportableSize retrieving: #(externalName reportableSize className oopString)