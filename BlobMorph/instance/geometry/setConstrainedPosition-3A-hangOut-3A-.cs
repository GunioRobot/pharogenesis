setConstrainedPosition: aPoint hangOut: partiallyOutside
	"Deal with dragging the blob over another blob which results in spontaneous deletations."

	self owner ifNil: [^ self].
	super setConstrainedPosition: aPoint hangOut: false.
		"note that we keep them from overlapping"