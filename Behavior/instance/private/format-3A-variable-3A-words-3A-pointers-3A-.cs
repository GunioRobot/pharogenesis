format: nInstVars variable: isVar words: isWords pointers: isPointers 
	"Set the format for the receiver (a Class)."
	| cClass instSpec sizeHiBits |
	self flag: #instSizeChange.
"
Smalltalk browseAllCallsOn: #instSizeChange.
Smalltalk browseAllImplementorsOf: #fixedFieldsOf:.
Smalltalk browseAllImplementorsOf: #instantiateClass:indexableSize:.
"
"
	NOTE: This code supports the backward-compatible extension to 8 bits of instSize.
	For now the format word is...
		<2 bits=instSize//64><5 bits=cClass><4 bits=instSpec><6 bits=instSize\\64><1 bit=0>
	But when we revise the image format, it should become...
		<5 bits=cClass><4 bits=instSpec><8 bits=instSize><1 bit=0>
"
	sizeHiBits _ (nInstVars+1) // 64.
	cClass _ 0.  "for now"
	instSpec _ isPointers
		ifTrue: [isVar
				ifTrue: [nInstVars>0 ifTrue: [3] ifFalse: [2]]
				ifFalse: [nInstVars>0 ifTrue: [1] ifFalse: [0]]]
		ifFalse: [isWords ifTrue: [6] ifFalse: [8]].
	format _ sizeHiBits.
	format _ (format bitShift: 5) + cClass.
	format _ (format bitShift: 4) + instSpec.
	format _ (format bitShift: 6) + ((nInstVars+1)\\64).  "+1 since prim size field includes header"
	format _ (format bitShift: 1) "This shift plus integer bit lets wordSize work like byteSize"
