transformedBy: aMorphicTransform
	"Return a copy of the receiver transformed by the given transformation."

	aMorphicTransform isIdentity ifTrue: [^ self].  "no transformation needed"
	^ self copy setCursorPoint: (aMorphicTransform transform: cursorPoint)
