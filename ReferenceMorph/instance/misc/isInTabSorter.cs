isInTabSorter
	"Answer whether the receiver is currently inside a tab sorter"
	^ (owner ~~ nil) and: [owner isKindOf: TabSorterMorph]