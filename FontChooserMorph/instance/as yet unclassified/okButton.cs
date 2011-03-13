okButton
	^okButton ifNil: [
		okButton := self basicButton 
			label: '     OK     ' translated; 
			target:self;
			actionSelector: #okButtonClicked;						
			setBalloonText: 
				'Click here to close this dialog, and accept your selection' translated]