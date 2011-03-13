drawText: aStringOrText on: aCanvas in: aRectangle
	"Draw the text on the canvas within the given bounds."
	
	self isEnabled
		ifTrue: [aCanvas
					drawString: aStringOrText
					in: aRectangle
					font: self fontToUse
					color: self stringColorToUse]
		ifFalse: [self theme disabledItemStyle = #inset
					ifTrue: [aCanvas
							drawString: aStringOrText
							in: (aRectangle translateBy: -1)
							font: self fontToUse
							color: self owner color muchDarker;
							drawString: aStringOrText
							in: aRectangle 
							font: self fontToUse
							color: self owner color lighter]
					ifFalse: [aCanvas
								drawString: aStringOrText
								in: aRectangle 
								font: self fontToUse
								color: self owner color muchDarker]].