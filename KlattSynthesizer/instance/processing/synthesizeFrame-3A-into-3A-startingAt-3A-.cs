synthesizeFrame: aKlattFrame into: aSoundBuffer startingAt: index
	<primitive: 'primitiveSynthesizeFrameIntoStartingAt' module: 'Klatt'>
	^(Smalltalk at: #KlattSynthesizerPlugin ifAbsent:[^self primitiveFail])
		doPrimitive: 'primitiveSynthesizeFrameIntoStartingAt'