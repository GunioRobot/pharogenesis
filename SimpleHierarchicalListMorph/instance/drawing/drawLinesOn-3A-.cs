drawLinesOn: aCanvas
	| lColor |
	lColor _ self lineColor.
	aCanvas 
		transformBy: scroller transform
		clippingTo: scroller innerBounds
		during:[:clippedCanvas |
			scroller submorphs do: [ :submorph |
				( 
					(submorph isExpanded) or: [
					(clippedCanvas isVisible: submorph fullBounds) or: [
					(submorph nextSibling notNil and: [clippedCanvas isVisible: submorph nextSibling]) 				]]) ifTrue:[
					submorph drawLinesOn: clippedCanvas lineColor: lColor.
				]
			].
		]
		smoothing: scroller smoothing.
