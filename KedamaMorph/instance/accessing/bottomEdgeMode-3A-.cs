bottomEdgeMode: aSymbol

	bottomEdgeMode _ aSymbol asSymbol.
	bottomEdgeMode == #wrap ifTrue: [
		bottomEdgeModeMnemonic _ 1.
		^ self
	].
	bottomEdgeMode == #stick ifTrue: [
		bottomEdgeModeMnemonic _ 2.
		^ self
	].
	(bottomEdgeMode == #bounce or: [bottomEdgeMode == #bouncing]) ifTrue: [
		bottomEdgeModeMnemonic _ 3.
		^ self
	].
