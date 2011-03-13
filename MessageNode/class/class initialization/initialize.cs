initialize		"MessageNode initialize"
	MacroSelectors _ 
		#(ifTrue: ifFalse: ifTrue:ifFalse: ifFalse:ifTrue:
			and: or:
			whileFalse: whileTrue: whileFalse whileTrue
			to:do: to:by:do:
			caseOf: caseOf:otherwise: as: ).
	MacroTransformers _ 
		#(transformIfTrue: transformIfFalse: transformIfTrueIfFalse: transformIfFalseIfTrue:
			transformAnd: transformOr:
			transformWhile: transformWhile: transformWhile: transformWhile:
			transformToDo: transformToDo:
			transformCase: transformCase: transformAs: ).
	MacroEmitters _ 
		#(emitIf:on:value: emitIf:on:value: emitIf:on:value: emitIf:on:value:
			emitIf:on:value: emitIf:on:value:
			emitWhile:on:value: emitWhile:on:value: emitWhile:on:value: emitWhile:on:value:
			emitToDo:on:value: emitToDo:on:value:
			emitCase:on:value: emitCase:on:value: emitAs:on:value: ).
	MacroSizers _ 
		#(sizeIf:value: sizeIf:value: sizeIf:value: sizeIf:value:
			sizeIf:value: sizeIf:value:
			sizeWhile:value: sizeWhile:value: sizeWhile:value: sizeWhile:value:
			sizeToDo:value: sizeToDo:value:
			sizeCase:value: sizeCase:value: sizeAs:value: ).
	MacroPrinters _ 
		#(printIfOn:indent: printIfOn:indent: printIfOn:indent: printIfOn:indent:
			printIfOn:indent: printIfOn:indent:
			printWhileOn:indent: printWhileOn:indent: printWhileOn:indent: printWhileOn:indent:
			printToDoOn:indent: printToDoOn:indent:
			printCase:indent: printCase:indent: printAs:indent: )