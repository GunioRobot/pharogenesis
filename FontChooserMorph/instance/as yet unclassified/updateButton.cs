updateButton
	^updateButton ifNil: [
		updateButton := self basicButton 
			label: ' Update ' translated; 
			target:self;
			actionSelector: #updateButtonClicked;						
			setBalloonText: 
				'Click here to rescan Font Folder and update the font list' translated]