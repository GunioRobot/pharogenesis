initialize		"MessageNode initialize"
	MacroSelectors _ 
		#(ifTrue: ifFalse: ifTrue:ifFalse: ifFalse:ifTrue:
			and: or:
			whileFalse: whileTrue: whileFalse whileTrue
			to:do: to:by:do:
			caseOf: caseOf:otherwise:
			ifNil: ifNotNil:  ifNil:ifNotNil: ifNotNil:ifNil:).
	MacroTransformers _ 
		#(transformIfTrue: transformIfFalse: transformIfTrueIfFalse: transformIfFalseIfTrue:
			transformAnd: transformOr:
			transformWhile: transformWhile: transformWhile: transformWhile:
			transformToDo: transformToDo:
			transformCase: transformCase:
			transformIfNil: transformIfNil:  transformIfNilIfNotNil: transformIfNotNilIfNil:).
	MacroEmitters _ 
		#(emitIf:on:value: emitIf:on:value: emitIf:on:value: emitIf:on:value:
			emitIf:on:value: emitIf:on:value:
			emitWhile:on:value: emitWhile:on:value: emitWhile:on:value: emitWhile:on:value:
			emitToDo:on:value: emitToDo:on:value:
			emitCase:on:value: emitCase:on:value:
			emitIfNil:on:value: emitIfNil:on:value: emitIf:on:value: emitIf:on:value:).
	MacroSizers _ 
		#(sizeIf:value: sizeIf:value: sizeIf:value: sizeIf:value:
			sizeIf:value: sizeIf:value:
			sizeWhile:value: sizeWhile:value: sizeWhile:value: sizeWhile:value:
			sizeToDo:value: sizeToDo:value:
			sizeCase:value: sizeCase:value:
			sizeIfNil:value: sizeIfNil:value: sizeIf:value: sizeIf:value: ).
	MacroPrinters _ 
		#(printIfOn:indent: printIfOn:indent: printIfOn:indent: printIfOn:indent:
			printIfOn:indent: printIfOn:indent:
			printWhileOn:indent: printWhileOn:indent: printWhileOn:indent: printWhileOn:indent:
			printToDoOn:indent: printToDoOn:indent:
			printCaseOn:indent: printCaseOn:indent:
			printIfNil:indent: printIfNil:indent: printIfNilNotNil:indent: printIfNilNotNil:indent:)