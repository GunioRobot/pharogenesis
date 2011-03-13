scrollUncheckedBy: heightToMove withSelectionFrom: startBlock to: stopBlock 
	"Scroll by the given amount.  Copy bits where possible, display the rest.
	If selection blocks are not nil, then select the newly visible text as well."
	| savedClippingRectangle delta |
	delta _ 0 @ (0 - heightToMove).
	compositionRectangle moveBy: delta.
	startBlock == nil ifFalse:
		[startBlock moveBy: delta.
		stopBlock moveBy: delta].
	savedClippingRectangle _ clippingRectangle.
	clippingRectangle _ clippingRectangle intersect: Display boundingBox.
	heightToMove abs >= clippingRectangle height
	  ifTrue: 
		["Entire visible region must be repainted"
		self displayLines: (1 to: lastLine) affectedRectangle: clippingRectangle]
	  ifFalse:
		["Copy bits where possible / display the rest"
		destinationForm
			copyBits: clippingRectangle from: destinationForm
			at: clippingRectangle topLeft + delta
			clippingBox: clippingRectangle
			rule: Form over fillColor: nil.
		"Set clippingRectangle to 'vacated' area for lines 'pulled' into view."
		clippingRectangle _ heightToMove < 0
			ifTrue:  "On the top"
				[clippingRectangle topLeft corner: clippingRectangle topRight + delta]
			ifFalse:  "At the bottom"
				[clippingRectangle bottomLeft + delta corner: clippingRectangle bottomRight].
		self displayLines: (1 to: lastLine)   "Refresh vacated region"
			affectedRectangle: clippingRectangle].
	startBlock == nil ifFalse:
		[self reverseFrom: startBlock to: stopBlock].
	"And restore the clippingRectangle to its original value. "
	clippingRectangle _ savedClippingRectangle