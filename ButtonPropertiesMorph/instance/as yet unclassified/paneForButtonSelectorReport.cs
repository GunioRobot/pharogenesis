paneForButtonSelectorReport

	^self inARow: {
		self lockedString: 'Action: ' translated.
 		UpdatingStringMorph new
			useStringFormat;
			getSelector: #actionSelector;
			target: self targetProperties;
			growable: true;
			minimumWidth: 24;
			lock.
	}
