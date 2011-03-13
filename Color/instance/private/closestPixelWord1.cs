closestPixelWord1
	"Return the nearest approximation to this color for a monochrome Form.  6/14/96 tk"

	self brightness > 0.5
		ifTrue: [ ^ 0 ]
		ifFalse: [ ^ 16rFFFFFFFF ].	"32 pixels by 1 bit each"