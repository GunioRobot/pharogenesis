displayOn: destForm at: destOrigin clippingBox: clipRect rule: rule fillColor: hf
	"Attempt to accelerate blts to aDisplayMedium"
	| sourceRect |
	((self isBltAccelerated: rule for: destForm) and:[hf = nil]) ifTrue:[
		"Try an accelerated blt"
		sourceRect _ (clipRect translateBy: destOrigin negated) intersect: clippingBox.
		(self primBltFast: bits to: destForm getExternalHandle
			at: 0@0 from: sourceRect origin
			extent: sourceRect extent) ifNotNil:[^self]].
	destForm copyBits: self boundingBox
		from: self
		at: destOrigin + self offset
		clippingBox: clipRect
		rule: rule
		fillColor: hf
		map: (self colormapIfNeededFor: destForm).
