computeTransform
	| fullExtent scale |
	fullExtent _ font bounds extent * 16.
	scale _ self extent asFloatPoint / fullExtent asFloatPoint.
	transform _ MatrixTransform2x3 withScale: scale.
	transform _ transform composedWithGlobal: (MatrixTransform2x3 withOffset: self position).
	^transform