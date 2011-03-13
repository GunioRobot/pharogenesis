format: nInstVars variable: isVar words: isWords pointers: isPointers 
	"Set the format for the receiver (a Class)."
	| cClass instSpec |
	"<5 bits=cClass><4 bits=instSpec><6 bits=instSize> all shifted left 1"
	cClass _ 0.  "for now"
	instSpec _ isPointers
		ifTrue: [isVar
				ifTrue: [nInstVars>0 ifTrue: [3] ifFalse: [2]]
				ifFalse: [nInstVars>0 ifTrue: [1] ifFalse: [0]]]
		ifFalse: [isWords ifTrue: [6] ifFalse: [8]].
	format _ cClass.
	format _ (format bitShift: 4) + instSpec.
	format _ (format bitShift: 6) + nInstVars+1.
	format _ (format bitShift: 1)