buildTopMVCWindowTitled: title model: model 
	| topWindow views buttons |
	topWindow _ StandardSystemView new model: model;
				 label: title;
				 minimumSize: 400 @ 250.
	views _ self buildViewsFor: model.
	buttons _ self buildButtonsFor: model.
	self
		addMVCViews: views
		andButtons: buttons
		to: topWindow.
	^ topWindow