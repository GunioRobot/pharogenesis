fillStyleToUse
	"Answer the fillStyle that should be used for the receiver."
	
	^self enabled
		ifTrue: [self theme textFieldNormalFillStyleFor: self]
		ifFalse: [self theme textFieldDisabledFillStyleFor: self]