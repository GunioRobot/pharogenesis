g: aFloatArray max: max focus: focus
	| dNormX array |

	dNormX _ aFloatArray - focus.
	
	array _ dNormX / max.
	array *= d.
	array += 1.0.
	array _ 1.0 / array.
	dNormX *= (d+1.0).
	array *= dNormX.
	^array += focus.
