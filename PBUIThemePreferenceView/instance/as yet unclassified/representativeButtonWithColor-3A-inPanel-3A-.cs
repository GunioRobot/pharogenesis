representativeButtonWithColor: aColor inPanel: aPreferencesPanel
	"Answer the morph for the panel."
	
	| innerPanel |
	innerPanel := self horizontalPanel
		addMorphBack: (self blankSpaceOf: 10@0);
		addMorphBack: self uiThemeRadioButtons;
		yourself.
	^self verticalPanel
		color: aColor;
		layoutInset: 2;
		addMorphBack: (StringMorph contents: self preferenceName);
		addMorphBack: innerPanel