topEdgeMode: aSymbol

	topEdgeMode _ aSymbol asSymbol.
	topEdgeMode == #wrap ifTrue: [
		topEdgeModeMnemonic _ 1.
		^ self
	].
	topEdgeMode == #stick ifTrue: [
		topEdgeModeMnemonic _ 2.
		^ self
	].
	(topEdgeMode == #bounce or: [topEdgeMode == #bouncing])  ifTrue: [
		topEdgeModeMnemonic _ 3.
		^ self
	].
