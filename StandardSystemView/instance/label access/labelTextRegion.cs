labelTextRegion
	labelText == nil ifTrue: [^ self labelDisplayBox center extent: 0@0].
	^ (labelText boundingBox
			align: labelText boundingBox center
			with: self labelDisplayBox center)
		intersect: (self labelDisplayBox insetBy: 35@0)