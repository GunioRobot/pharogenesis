magnifyBy: aNumber 
	"private - scale the video (if any) to a scale of the normalExtent"
	| ne |
	fullScreen := false.""
	ne := self normalExtent.
	ne isNil
		ifFalse: [self extent: (ne * aNumber) rounded]