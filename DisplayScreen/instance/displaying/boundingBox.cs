boundingBox
	clippingBox == nil
		ifTrue: [clippingBox _ super boundingBox].
	^ clippingBox