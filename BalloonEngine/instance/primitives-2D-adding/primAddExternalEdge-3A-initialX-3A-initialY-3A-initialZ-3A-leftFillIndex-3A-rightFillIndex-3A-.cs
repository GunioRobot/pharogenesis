primAddExternalEdge: index initialX: initialX initialY: initialY initialZ: initialZ leftFillIndex: leftFillIndex rightFillIndex: rightFillIndex
	<primitive: 'gePrimitiveRegisterExternalEdge'>
	(self canProceedAfter: self primGetFailureReason) ifTrue:[
		^self primAddExternalEdge: index initialX: initialX initialY: initialY initialZ: initialZ leftFillIndex: leftFillIndex rightFillIndex: rightFillIndex
	].
	^self primitiveFailed