paragraph
	"Paragraph instantiation is lazy -- create it only when needed"
	paragraph ifNotNil: [^ paragraph].
	self setDefaultContentsIfNil.

	"...Code here to recreate the paragraph..."
	paragraph _ (self paragraphClass new textOwner: self meOrMyDropShadow owner)
					compose: text style: textStyle copy
					from: self startingIndex in: self container.
	wrapFlag ifFalse:
		["Was given huge container at first... now adjust"
		paragraph adjustRightX].
	self fit.
	^ paragraph