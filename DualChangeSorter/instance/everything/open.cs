open
	"1991, tk.  Modified 5/16/96 sw: decrease minimum size drastically
	 : more modest minimum size, and other minor adjustments
	 : more useful choice for initial cs in second sorter"

	| topView |
	leftCngSorter _ ChangeSorter new initializeFor: Smalltalk changes.
	leftCngSorter parent: self.
	rightCngSorter _ ChangeSorter new initializeFor: ChangeSorter secondaryChangeSet.
	rightCngSorter parent: self.

	topView _ StandardSystemView new.
	topView model: self.
	topView label: leftCngSorter label.
	topView minimumSize: 300 @ 200.
	self openView: topView.
	topView controller open