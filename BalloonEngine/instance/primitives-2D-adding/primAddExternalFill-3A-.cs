primAddExternalFill: index
	<primitive: 'gePrimitiveRegisterExternalFill'>
	(self canProceedAfter: self primGetFailureReason) ifTrue:[
		^self primAddExternalFill: index
	].
	^self primitiveFailed