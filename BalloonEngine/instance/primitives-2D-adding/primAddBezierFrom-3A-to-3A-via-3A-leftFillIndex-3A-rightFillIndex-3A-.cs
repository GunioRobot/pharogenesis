primAddBezierFrom: start to: end via: via leftFillIndex: leftFillIndex rightFillIndex: rightFillIndex
	<primitive: 'gePrimitiveAddBezier'>
	(self canProceedAfter: self primGetFailureReason) ifTrue:[
		^self primAddBezierFrom: start to: end via: via leftFillIndex: leftFillIndex rightFillIndex: rightFillIndex
	].
	^self primitiveFailed