cancelButton
	^cancelButton ifNil: [
		cancelButton := self basicButton 
			label: ' Cancel ' translated; 
			target:self;
			actionSelector: #cancelButtonClicked;						
			setBalloonText: 
				'Click here to cancel and close this dialog' translated]