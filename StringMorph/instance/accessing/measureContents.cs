measureContents
	| f |
	f _ self fontToUse.
	^(((f widthOfString: contents) max: self minimumWidth)  @ f height).