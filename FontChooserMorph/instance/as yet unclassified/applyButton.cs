applyButton
	^applyButton ifNil: [
		applyButton := self basicButton 
			label: ' Apply ' translated; 
			target:self;
			actionSelector: #applyButtonClicked;						
			setBalloonText: 
				'Click here to apply your selection without closing this dialog' translated]