maskingMap: depth
	"Return a color map that maps all colors except transparent to words of all ones. Used to create a mask for a Form whose transparent pixel value is zero. Cache the most recently used map."

	| sizeNeeded |
	depth <= 8
		ifTrue: [sizeNeeded _ 1 bitShift: depth]
		ifFalse: [sizeNeeded _ 4096].
	MaskingMap size = sizeNeeded ifTrue: [^ MaskingMap].

	MaskingMap _ Bitmap new: sizeNeeded withAll: 16rFFFFFFFF.
	MaskingMap at: 1 put: 0.  "transparent"

	^ MaskingMap
