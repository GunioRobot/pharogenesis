drawPageForwardOn: aCanvas
	"startForm shrinks in the given direction, revealing endForm."
	| offset shrinkRect scale |
	aCanvas drawImage: endForm at: self position.

	offset _ self stepFrom: 0@0 to: self extent * direction.
	shrinkRect _ (bounds translateBy: offset) intersect: bounds.
	scale _ shrinkRect extent asFloatPoint / bounds extent.
	aCanvas drawImage: (startForm magnify: startForm boundingBox by: scale smoothing: 1)
		at: shrinkRect topLeft.

	((shrinkRect translateBy: direction negated) areasOutside: shrinkRect) do:
		[:r | aCanvas fillRectangle: r color: Color black].
