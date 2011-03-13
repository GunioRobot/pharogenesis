initializeLayout
	"Initialize the layout."

	self
		changeTableLayout;
		layoutInset: 16;
		vResizing: #shrinkWrap;
		hResizing: #rigid;
		extent: self minimumExtent