codePaneProvenanceButton
	"Answer a button that reports on, and allow the user to modify,
	the code-pane-provenance setting"
	| aButton |
	aButton := UpdatingSimpleButtonMorph newWithLabel: 'source'.
	aButton setNameTo: 'codeProvenance'.
	aButton useSquareCorners.
	aButton target: self;
		 wordingSelector: #codePaneProvenanceString;
		 actionSelector: #offerWhatToShowMenu.
	aButton setBalloonText: 'Governs what view is shown in the code pane.  Click here to change the view'.
	aButton actWhen: #buttonDown.
	aButton color: Color white;
		borderStyle: BorderStyle thinGray; vResizing: #spaceFill.
	^ aButton