leftEdgeMode: aSymbol

	leftEdgeMode _ aSymbol asSymbol.
	leftEdgeMode == #wrap ifTrue: [
		leftEdgeModeMnemonic _ 1.
		^ self
	].
	leftEdgeMode == #stick ifTrue: [
		leftEdgeModeMnemonic _ 2.
		^ self
	].
	(leftEdgeMode == #bounce or: [leftEdgeMode == #bouncing]) ifTrue: [
		leftEdgeModeMnemonic _ 3.
		^ self
	].
