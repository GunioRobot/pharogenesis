loadPrimitiveLightSource
	self inline: true.
	lightFlags _ (self cCoerce: primLight to: 'int*') at: PrimLightFlags.