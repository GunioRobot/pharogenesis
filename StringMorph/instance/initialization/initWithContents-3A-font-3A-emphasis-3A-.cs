initWithContents: aString font: aFont emphasis: emphasisCode
	super initialize.
	color _ Color black.
	font _ aFont.
	emphasis _ emphasisCode.
	hasFocus _ false.
	self contents: aString.