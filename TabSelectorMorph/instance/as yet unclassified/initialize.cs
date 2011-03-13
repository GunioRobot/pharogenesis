initialize
	"Initialize the receiver."

	super initialize.
	selectedIndex := 0.
	self
		roundedCorners: #(1 4);
		borderWidth: 0;
		changeTableLayout;
		listDirection: #leftToRight;
		cellInset: (self theme tabSelectorCellInsetFor: self)