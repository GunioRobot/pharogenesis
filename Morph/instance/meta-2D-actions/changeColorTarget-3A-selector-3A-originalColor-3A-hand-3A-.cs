changeColorTarget: anObject selector: aSymbol originalColor: aColor hand: aHand
	"Put up a color picker for changing some kind of color.  May be modal or modeless, depending on #modalColorPickers setting"
	self flag: #arNote. "Simplify this due to anObject == self for almost all cases"
	^ ColorPickerMorph new
		choseModalityFromPreference;
		sourceHand: aHand;
		target: anObject;
		selector: aSymbol;
		originalColor: aColor;
		putUpFor: anObject near: (anObject isMorph
					ifTrue:	 [Rectangle center: self position extent: 20]
					ifFalse: [anObject == self world
								ifTrue: [anObject viewBox bottomLeft + (20@-20) extent: 200]
								ifFalse: [anObject fullBoundsInWorld]]);
		yourself