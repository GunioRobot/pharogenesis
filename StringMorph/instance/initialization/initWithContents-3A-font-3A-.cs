initWithContents: aString font: aFont
	super initialize.
	color _ Color black.
	font _ aFont.
	hasFocus _ false.
	self contents: aString.