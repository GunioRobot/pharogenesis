withPassenger: anObject from: source 
	| ddm |
	ddm _ self new.
	ddm passenger: anObject.
	ddm source: source.
	Sensor shiftPressed ifTrue: [ddm shouldCopy: true].
	^ ddm