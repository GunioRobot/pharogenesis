noteNewMethod: newMethod selector: selector priorMethod: methodOrNil

	| methodChange |
	methodChange _ self findOrMakeMethodChangeAt: selector priorMethod: methodOrNil.
	methodOrNil == nil
		ifTrue: [methodChange noteChangeType: #add]
		ifFalse: [methodChange noteChangeType: #change].
	methodChange noteNewMethod: newMethod.
