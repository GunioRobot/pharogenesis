scrollbarNormalThumbBorderStyleFor: aScrollbar
	"Return the normal thumb borderStyle for the given scrollbar."

	|aColor|
	aColor := self scrollbarColorFor: aScrollbar.
	^BorderStyle raised
		width: 1;
		baseColor: aColor twiceDarker