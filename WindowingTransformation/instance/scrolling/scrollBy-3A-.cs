scrollBy: aPoint 
	"Answer a WindowingTransformation with the same scale as the receiver 
	and with a translation of the current translation plus aPoint scaled by 
	the current scale. It is used when the translation is known in source 
	coordinates, rather than scaled source coordinates (see 
	WindowingTransformation|translateBy:). An example is that of scrolling 
	objects with respect to a stationary window in the source coordinate 
	system. If no scaling is in effect (scale = nil), then 
	WindowingTransformation|translateBy: and 
	WindowingTransformation|scrollBy: are equivalent."

	| newTranslation |
	scale == nil
		ifTrue: [newTranslation := aPoint]
		ifFalse: [newTranslation := scale * aPoint].
	^self translateBy: newTranslation