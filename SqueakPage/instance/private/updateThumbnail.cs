updateThumbnail
	"Update my thumbnail from my morph."

	| f scale scaleX scaleY shrunkF |
	contentsMorph ifNil: [thumbnail _ nil. ^ self].
	f _ contentsMorph imageForm.
	scaleX _ MaxThumbnailWidthOrHeight asFloat / f height.
	scaleY _ MaxThumbnailWidthOrHeight asFloat/ f width.
	scale _ scaleX min: scaleY.  "choose scale that maintains aspect ratio"
	shrunkF _ (f magnify: f boundingBox by: scale@scale smoothing: 2).
	thumbnail _ Form extent: shrunkF extent depth: 8.  "force depth to be 8"
	shrunkF displayOn: thumbnail.
	contentsMorph allMorphsDo: [:m | m releaseCachedState].
