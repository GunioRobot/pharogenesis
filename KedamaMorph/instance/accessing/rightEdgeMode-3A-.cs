rightEdgeMode: aSymbol

	rightEdgeMode _ aSymbol asSymbol.
	rightEdgeMode == #wrap ifTrue: [
		rightEdgeModeMnemonic _ 1.
		^ self
	].
	rightEdgeMode == #stick ifTrue: [
		rightEdgeModeMnemonic _ 2.
		^ self
	].
	(rightEdgeMode == #bounce or: [rightEdgeMode == #bouncing]) ifTrue: [
		rightEdgeModeMnemonic _ 3.
		^ self
	].
