simpleToggleButtonFor: target attribute: attribute help: helpText

	^(EtoyUpdatingThreePhaseButtonMorph checkBox)
		target: target;
		actionSelector: #toggleChoice:;
		arguments: {attribute};
		getSelector: #getChoice:;
		setBalloonText: helpText;
		step

