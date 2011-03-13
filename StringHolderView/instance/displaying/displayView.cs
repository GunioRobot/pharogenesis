displayView 
	"Refer to the comment in View|displayView."

	self clearInside.
	(self controller isKindOf: ParagraphEditor)
		ifTrue: [controller display]
		ifFalse: [displayContents display]