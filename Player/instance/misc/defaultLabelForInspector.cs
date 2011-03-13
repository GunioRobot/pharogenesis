defaultLabelForInspector
	"Answer the default label to be used for an Inspector window on the receiver."
	^ self externalName ifNil: ['An unaffiliated Player'] ifNotNil: [self externalName]