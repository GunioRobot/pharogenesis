representativeButtonWithColor: aColor inPanel: aPreferencesPanel
	| outerButton editButton |
	editButton := SimpleButtonMorph new 
					target: Preferences; 
					color: Color transparent; 
					actionSelector: #editCustomHalos; 
					label: 'Edit custom halos' translated;
					setBalloonText: 'Click here to edit the method that defines the custom halos' translated.
	
	outerButton := AlignmentMorph newColumn.
	outerButton
		color:  (aColor ifNil: [Color r: 0.645 g: 1.0 b: 1.0]);
		hResizing: (aPreferencesPanel ifNil: [#shrinkWrap] ifNotNil: [#spaceFill]);
		vResizing: #shrinkWrap;	
		addTransparentSpacerOfSize: (0@4);
		addMorphBack: self haloThemeRadioButtons;
		addTransparentSpacerOfSize: (0@4);
		addMorphBack: editButton.
		
	^outerButton.
	
	"(Preferences preferenceAt: #haloTheme) view tearOffButton"	