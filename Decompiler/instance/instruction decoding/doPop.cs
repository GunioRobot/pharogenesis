doPop

	stack last == CaseFlag
		ifTrue: [stack removeLast]
		ifFalse: [statements addLast: stack removeLast].