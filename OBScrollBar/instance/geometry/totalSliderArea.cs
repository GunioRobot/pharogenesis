totalSliderArea
	| upperBoundsButton |
	upperBoundsButton _ upButton.
	upButton bottom > upperBoundsButton bottom
		ifTrue: [upperBoundsButton _ upButton].
	^ bounds isWide
		ifTrue: [upperBoundsButton bounds topRight corner: downButton bounds bottomLeft]
		ifFalse: [upperBoundsButton bounds bottomLeft corner: downButton bounds topRight].
