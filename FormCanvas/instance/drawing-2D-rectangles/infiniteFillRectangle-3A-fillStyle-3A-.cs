infiniteFillRectangle: aRectangle fillStyle: aFillStyle

	^aFillStyle
		displayOnPort: (port clippedBy: (aRectangle translateBy: origin)) 
		at: aRectangle origin + origin
