scrollbarPressedThumbFillStyleFor: aScrollbar
	"Return the pressed scrollbar thumb fillStyle for the given scrollbar."
	
	|aColor|
	aColor := self scrollbarColorFor: aScrollbar.
	^(GradientFillStyle ramp: {
			0.0->aColor darker duller. 0.2-> aColor darker.
			0.8->aColor twiceLighter. 1.0->Color white})
		origin: aScrollbar topLeft;
		direction: (aScrollbar bounds isWide
			ifTrue: [0 @ aScrollbar height]
			ifFalse: [aScrollbar width @ 0]);
		radial: false