changeColorTarget: aMorph selector: aSymbol originalColor: aColor

	^ ColorPickerMorph new
		sourceHand: self;
		target: aMorph;
		selector: aSymbol;
		originalColor: aColor;
		addToWorld: self world
			near: (aMorph
					ifNil: [Rectangle center: self position extent: 20]
					ifNotNil: [aMorph == self world
								ifTrue: [aMorph viewBox bottomLeft + (20@-20) extent: 200]
								ifFalse: [aMorph fullBounds]]);
		yourself