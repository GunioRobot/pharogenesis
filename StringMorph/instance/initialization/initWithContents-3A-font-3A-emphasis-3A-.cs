initWithContents: aString font: aFont emphasis: emphasisCode 
	super initialize.
	
	font _ aFont.
	emphasis _ emphasisCode.
	hasFocus _ false.
	self contents: aString