displayBorder
	"Display the receiver's border (using the receiver's borderColor)."

	borderWidth = 0
		ifTrue:
			[insideColor == nil
				ifFalse: 
					[Display fill: self displayBox fillColor: self backgroundColor]]
		ifFalse:
			[Display
				border: self displayBox
				widthRectangle: borderWidth
				rule: Form over
				fillColor: self foregroundColor.
			insideColor == nil ifFalse:
				[Display fill: self insetDisplayBox fillColor: self backgroundColor]]