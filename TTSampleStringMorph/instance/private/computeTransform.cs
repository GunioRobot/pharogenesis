computeTransform
	| cy |
	cy _ bounds origin y + bounds corner y * 0.5.
	transform _ MatrixTransform2x3 
			transformFromLocal: (ttBounds insetBy: borderWidth negated)
			toGlobal: bounds.
	transform _ transform composedWithGlobal:(MatrixTransform2x3 withOffset: 0@cy negated).
	transform _ transform composedWithGlobal:(MatrixTransform2x3 withScale: 1.0@-1.0).
	transform _ transform composedWithGlobal:(MatrixTransform2x3 withOffset: 0@cy).
	^transform