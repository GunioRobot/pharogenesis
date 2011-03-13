clippingTo: aRect do: aBlock
	"Display clippingTo: Rectangle fromUser do:
	[ScheduledControllers restore: Display fullBoundingBox]"
	| saveClip |
	saveClip _ clippingBox.
	clippingBox _ aRect.
	aBlock value.
	clippingBox _ saveClip