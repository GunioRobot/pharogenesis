primAddBezierShape: points segments: nSegments fill: fillStyle lineWidth: lineWidth lineFill: lineFill
	<primitive: 'gePrimitiveAddBezierShape'>
	(self canProceedAfter: self primGetFailureReason) ifTrue:[
		^self primAddBezierShape: points segments: nSegments fill: fillStyle lineWidth: lineWidth lineFill: lineFill
	].
	^self primitiveFailed