labelHeight
	"Answer the height for the window label.  The standard behavior is at bottom; a hook is provided so that models can stipulate other heights, in support of various less-window-looking demos.
	If no label answer the class border width instead."

	| aHeight |
	(model notNil and: [model respondsTo: #desiredWindowLabelHeightIn:]) ifTrue:
		[(aHeight := model desiredWindowLabelHeightIn: self) ifNotNil: [^ aHeight]].

	^ label ifNil: [self class borderWidth] ifNotNil:
		 [(label height + (self class borderWidth * 2)) max:
			(collapseBox ifNotNil: [collapseBox height] ifNil: [10])]