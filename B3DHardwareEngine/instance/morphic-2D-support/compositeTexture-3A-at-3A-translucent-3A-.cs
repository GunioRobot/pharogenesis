compositeTexture: aTexture at: aPoint translucent: aBool
	"Composite the given texture at aPoint into the receiver."
	self primRender: handle
		compositeTexture: aTexture getExternalHandle
		x: aPoint x
		y: aPoint y
		w: aTexture width
		h: aTexture height
		translucent: aBool.