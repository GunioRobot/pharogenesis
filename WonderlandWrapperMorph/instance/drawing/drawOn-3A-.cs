drawOn: aCanvas
	| morph |
	morph _ self getCameraMorph.
	morph == nil
		ifTrue:[super drawOn: aCanvas]
		ifFalse:[self computeBounds: morph. "Update bounds from camera"
			false ifTrue:["Show a rectangle for the wrappers"
				aCanvas frameRectangle: bounds color: Color white]]