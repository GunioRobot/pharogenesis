editString: aString 
	self okToStyle ifFalse:[^super editString: aString].
	super editString: (styler format: aString asText).
	aString size < 4096
		ifTrue:[	styler style: displayContents text]
		ifFalse:[styler styleInBackgroundProcess: displayContents text]