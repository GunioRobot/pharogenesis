setConstrainedPositionFrom: aPoint
	"Deal with dragging the blob over another blob
	which results in spontaneous deletations."

	self owner ifNil: [^ self].
	super setConstrainedPositionFrom: aPoint