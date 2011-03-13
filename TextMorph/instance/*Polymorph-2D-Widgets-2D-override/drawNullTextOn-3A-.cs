drawNullTextOn: aCanvas
	"Make null text frame visible.
	Nicer if not shaded!"

	aCanvas isPostscriptCanvas ifFalse: [
	aCanvas fillRectangle: bounds color: (self backgroundColor ifNil: [Color transparent])]