initalizeAsDialogBox
	self initalizeBasicParameters.
	self createDialogBoxUI.
	self morphicView
		useRoundedCorners;
		color: Preferences menuColor;
		adoptPaneColor: Preferences menuLineColor.
	self 
		setCaptionColor: Preferences menuTitleColor;
		setButtonColor: Preferences menuColor.