recordNextChar: glyphIndex advanceWidth: advance
	| shape transform |
	(activeFont includesKey: glyphIndex) ifTrue:[
		shape _ (activeFont at: glyphIndex) veryDeepCopy reset.
		"Must include the textMorph's transform here - it might be animated"
		transform _  ((MatrixTransform2x3 withOffset: textOffset) 
							setScale: (textHeight@textHeight) / 1024.0).
		transform _ transform composedWithGlobal: textMorph transform.
		shape transform: transform.
		shape color: textMorph color.
		textMorph addMorphBack: shape.].
	textOffset _ textOffset + (advance@0).