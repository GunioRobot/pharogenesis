totalSliderArea
	| upperBoundsButton |
	upperBoundsButton _ menuButton ifNil: [upButton].
	bounds isWide
		ifTrue: [
			upButton right > upperBoundsButton right
				ifTrue: [upperBoundsButton _ upButton].
			^upperBoundsButton bounds topRight corner: downButton bounds bottomLeft]
		ifFalse:[
			upButton bottom > upperBoundsButton bottom
				ifTrue: [upperBoundsButton _ upButton].
			^upperBoundsButton bounds bottomLeft corner: downButton bounds topRight].
