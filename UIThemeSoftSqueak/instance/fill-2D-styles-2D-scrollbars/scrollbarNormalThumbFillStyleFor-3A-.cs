scrollbarNormalThumbFillStyleFor: aScrollbar
	"Return the normal scrollbar thumb fillStyle for the given scrollbar."
	
	|aColor|
	aColor := self scrollbarColorFor: aScrollbar.
	^(GradientFillStyle ramp: {
			0.0->Color white. 0.2-> aColor twiceLighter.
			0.8->aColor darker. 1.0->aColor darker duller})
		origin: aScrollbar topLeft;
		direction: (aScrollbar bounds isWide
			ifTrue: [0 @ aScrollbar height]
			ifFalse: [aScrollbar width @ 0]);
		radial: false