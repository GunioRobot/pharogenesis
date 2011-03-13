groupToggleButton

	^(self inAColumn: {
		(EtoyUpdatingThreePhaseButtonMorph checkBox)
			target: self;
			actionSelector: #toggleChoice:;
			arguments: {'group'};
			getSelector: #getChoice:;
			setBalloonText: 'Changes between group mode and individuals';
			step
	}) hResizing: #shrinkWrap
