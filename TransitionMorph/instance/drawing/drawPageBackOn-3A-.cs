drawPageBackOn: aCanvas
	"endForm grows in the given direction, overlaying endForm."
	| offset growRect scale |
	aCanvas drawImage: startForm at: self position.

	offset _ self stepFrom: self extent * direction negated to: 0@0.
	growRect _ (bounds translateBy: offset) intersect: bounds.
	scale _ growRect extent asFloatPoint / bounds extent.
	aCanvas drawImage: (endForm magnify: endForm boundingBox by: scale smoothing: 1)
		at: growRect topLeft.

	((growRect translateBy: direction) areasOutside: growRect) do:
		[:r | aCanvas fillRectangle: r color: Color black].
