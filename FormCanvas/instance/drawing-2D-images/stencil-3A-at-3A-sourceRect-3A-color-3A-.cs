stencil: stencilForm at: aPoint sourceRect: sourceRect color: aColor
	"Flood this canvas with aColor wherever stencilForm has non-zero pixels"
	port isFXBlt "FXBlt has a very different setup"
		ifTrue:[self setStencilColor: aColor form: stencilForm]
		ifFalse:[self setPaintColor: aColor.
				port colorMap: (Color maskingMap: stencilForm depth)].
	port stencil: stencilForm
		at: aPoint + origin
		sourceRect: sourceRect.