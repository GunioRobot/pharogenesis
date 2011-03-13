addMouseUpAction 

	| codeToRun oldCode |

	oldCode _ self valueOfProperty: #mouseUpCodeToRun ifAbsent: [''].
	codeToRun _ FillInTheBlank request: 'MouseUp expression:' initialAnswer: oldCode.
	self addMouseUpActionWith: codeToRun

