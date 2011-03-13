makeMultipleSiblings: evt
	"Make multiple siblings, first prompting the user for how many"

	| result |
	result _ FillInTheBlank request: 'how many siblings do you want?' initialAnswer: '2'.
	result isEmptyOrNil ifTrue: [^ self].
	result first isDigit ifFalse: [^ self beep].
	self topRendererOrSelf makeSiblings: result asInteger.