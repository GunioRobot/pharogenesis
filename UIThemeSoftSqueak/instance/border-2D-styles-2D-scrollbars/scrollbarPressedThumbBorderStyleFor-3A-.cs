scrollbarPressedThumbBorderStyleFor: aScrollbar
	"Return the pressed thumb borderStyle for the given scrollbar."

	|aColor|
	aColor := self scrollbarColorFor: aScrollbar.
	^BorderStyle inset
		width: 1;
		baseColor: aColor twiceDarker