initialize
	super initialize.
	activeSlots _ 0.
	bars _ Array new: 10.
	labels _ Array new: 10.
	font _ Preferences windowTitleFont.
	lock _ Semaphore forMutualExclusion.
	self setDefaultParameters;
		setProperty: #morphicLayerNumber toValue: self morphicLayerNumber;
		layoutPolicy: TableLayout new;
		listDirection: #topToBottom;
		cellPositioning: #topCenter;
		cellInset: 5;
		listCentering: #center;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		layoutInset:4@4.