drawOn: aCanvas
	"Draw the current frame image, if there is one. Otherwise, fill screen with gray."

	frameBuffer
		ifNil: [aCanvas fillRectangle: self bounds color: (Color gray: 0.75)]
		ifNotNil: [
			self extent = frameBuffer extent
				ifTrue: [aCanvas drawImage: frameBuffer at: bounds origin]
				ifFalse: [self drawScaledOn: aCanvas]].
