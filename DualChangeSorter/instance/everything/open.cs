open
	"1991, tk.  Modified 5/16/96 sw: decrease minimum size drastically
	 6/18/96 sw: more modest minimum size, and other minor adjustments"

	| topView |
	leftCngSorter _ ChangeSorter new initialize.
	leftCngSorter parent: self.
	rightCngSorter _ ChangeSorter new initialize.
	rightCngSorter parent: self.

	topView _ StandardSystemView new.
	topView model: self.
	topView label: leftCngSorter label.
	topView minimumSize: 300 @ 200.
	self openView: topView.
	topView controller open