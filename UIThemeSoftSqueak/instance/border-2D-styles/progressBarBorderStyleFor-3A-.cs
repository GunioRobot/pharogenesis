progressBarBorderStyleFor: aProgressBar
	"Return the progress bar borderStyle for the given progress bar."

	|c|
	c := self progressBarColorFor: aProgressBar.
	^BorderStyle inset
		width: 1;
		baseColor: c