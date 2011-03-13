measureContents
	"Round up in case fractional."
	
	| f |
	f := self fontToUse.
	^(((f widthOfString: contents) max: self minimumWidth)  @ f height) ceiling