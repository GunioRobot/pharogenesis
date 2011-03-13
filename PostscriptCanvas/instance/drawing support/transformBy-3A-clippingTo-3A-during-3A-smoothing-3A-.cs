transformBy: aDisplayTransform clippingTo: aClipRect during: aBlock smoothing: cellSize

	| retval |
	self comment: 'drawing clipped ' with: aClipRect.
	self comment: 'drawing transformed ' with: aDisplayTransform.
     self preserveStateDuring: [ :inner | 
		currentTransformation ifNil: [
			currentTransformation _ aDisplayTransform
		] ifNotNil: [
			currentTransformation _ currentTransformation composedWithLocal: aDisplayTransform
		].
		aClipRect ifNotNil: [
			clipRect _ aDisplayTransform globalBoundsToLocal: (clipRect intersect: aClipRect) .
			inner rect: aClipRect; clip.
		].
		inner transformBy: aDisplayTransform.
		retval _ aBlock value: inner
	].	
	self comment: 'end of drawing clipped ' with: aClipRect.
	^ retval
