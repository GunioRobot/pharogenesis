transformBy: aDisplayTransform clippingTo: aClipRect during: aBlock smoothing: cellSize
	"Note: This method has been originally copied from TransformationMorph."
	| innerRect patchRect sourceQuad warp start subCanvas |
	(aDisplayTransform isPureTranslation) ifTrue:[
		subCanvas _ self copyOffset: aDisplayTransform offset negated truncated
							clipRect: aClipRect.
		aBlock value: subCanvas.
		foundMorph _ subCanvas foundMorph.
		^self
	].
	"Prepare an appropriate warp from patch to innerRect"
	innerRect _ aClipRect.
	patchRect _ aDisplayTransform globalBoundsToLocal:
					(self clipRect intersect: innerRect).
	sourceQuad _ (aDisplayTransform sourceQuadFor: innerRect)
					collect: [:p | p - patchRect topLeft].
	warp _ self warpFrom: sourceQuad toRect: innerRect.
	warp cellSize: cellSize.

	"Render the submorphs visible in the clipping rectangle, as patchForm"
	start _ (self depth = 1 and: [self isShadowDrawing not])
		"If this is true B&W, then we need a first pass for erasure."
		ifTrue: [1] ifFalse: [2].
	start to: 2 do:
		[:i | "If i=1 we first make a shadow and erase it for opaque whites in B&W"
		subCanvas _ ColorPatchCanvas extent: patchRect extent depth: self depth.
		subCanvas stopMorph: stopMorph.
		subCanvas foundMorph: foundMorph.
		subCanvas doStop: doStop.
		i=1	ifTrue: [subCanvas shadowColor: Color black.
					warp combinationRule: Form erase]
			ifFalse: [self isShadowDrawing ifTrue:
					[subCanvas shadowColor: self shadowColor].
					warp combinationRule: Form paint].
		subCanvas translateBy: patchRect topLeft negated
			during:[:offsetCanvas| aBlock value: offsetCanvas].
		i = 2 ifTrue:[foundMorph _ subCanvas foundMorph].
		warp sourceForm: subCanvas form; warpBits.
		warp sourceForm: nil.  subCanvas _ nil "release space for next loop"]
