paragraph
	"Paragraph instantiation is lazy -- create it only when needed"
	paragraph ifNotNil: [^ paragraph].
	text ifNil: [text _ 'Text' asText allBold].  "Default contents"

	"...Code here to recreate the paragraph..."
	paragraph _ (self paragraphClass new textOwner: owner)
					compose: text style: textStyle copy
					from: self startingIndex in: self container.
	wrapFlag ifFalse:
		["Was given huge container at first... now adjust"
		paragraph adjustRightX].
	self fit.
	^ paragraph