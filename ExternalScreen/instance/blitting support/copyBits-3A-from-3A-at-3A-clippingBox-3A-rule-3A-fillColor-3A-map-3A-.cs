copyBits: sourceRect from: sourceForm at: destOrigin clippingBox: clipRect rule: rule fillColor: hf map: map
	"Attempt to accelerate blts to the receiver"
	| r |
	((self isBltAccelerated: rule for: sourceForm) and:[map == nil and:[hf == nil]]) ifTrue:[
		"Try an accelerated blt"
		r _ (destOrigin extent: sourceRect extent) intersect: (clipRect intersect: clippingBox).
		r area <= 0 ifTrue:[^self].
		(self primBltFast: bits from: sourceForm getExternalHandle
			at: r origin from: sourceRect origin
			extent: r extent) ifNotNil:[^self].
	].
	^super copyBits: sourceRect from: sourceForm at: destOrigin clippingBox: clipRect rule: rule fillColor: hf map: map