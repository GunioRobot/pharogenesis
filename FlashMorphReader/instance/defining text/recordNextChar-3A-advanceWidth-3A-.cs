recordNextChar: glyphIndex advanceWidth: advance
	| shape transform |
	(activeFont includesKey: glyphIndex) ifTrue:[
		shape := (activeFont at: glyphIndex) veryDeepCopy reset.
		"Must include the textMorph's transform here - it might be animated"
		transform :=  ((MatrixTransform2x3 withOffset: textOffset) 
							setScale: (textHeight@textHeight) / 1024.0).
		transform := transform composedWithGlobal: textMorph transform.
		shape transform: transform.
		shape color: textMorph color.
		textMorph addMorphBack: shape.].
	textOffset := textOffset + (advance@0).