extent: aPoint
	"Set my image form to the given extent."

	| newExtent scaleP scale fillColor |
	((bounds extent = aPoint) and:
	 [image depth = Display depth]) ifFalse: [
		lastProjectThumbnail
			ifNil: [newExtent _ aPoint]
			ifNotNil: [
				scaleP _ aPoint / lastProjectThumbnail extent.
				scale _ scaleP x asFloat max: scaleP y asFloat.
				newExtent _ (lastProjectThumbnail extent * scale) rounded].
		self image: (Form extent: newExtent depth: Display depth).
		project world
			ifNil: [fillColor _ project world color]
			ifNotNil: [fillColor _ Color veryLightGray].
		image fill: image boundingBox fillColor: fillColor.
		lastProjectThumbnail _ nil].
