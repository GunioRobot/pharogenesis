displayView 
	"Refer to the comment in View|displayView."

	Display deferUpdatesIn: self displayBox while: [
		self clearInside.
		(self controller isKindOf: ParagraphEditor)
			ifTrue: [controller display]
			ifFalse: [displayContents display]]