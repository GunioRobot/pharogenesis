renderOn: aRenderer
	(color isTransparent or:[color isTranslucent]) 
		ifTrue:[aRenderer restoreMorphicBackground: self bounds under: self].
	aRenderer viewport: self bounds.
	aRenderer clearDepthBuffer.
	color isTransparent 
		ifFalse:[aRenderer clearViewport: color].
	aRenderer loadIdentity.
	scene renderOn: aRenderer.
	aRenderer restoreMorphicForeground: self bounds above: self.
