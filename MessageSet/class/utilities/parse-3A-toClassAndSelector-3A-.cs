parse: methodRef toClassAndSelector: csBlock
	"Decode strings of the form <className> [class] <selectorName>."

	| tuple cl |


	self flag: #mref.	"compatibility with pre-MethodReference lists"

	methodRef ifNil: [^ csBlock value: nil value: nil].
	(methodRef isKindOf: MethodReference) ifTrue: [
		^methodRef setClassAndSelectorIn: csBlock
	].
	methodRef isEmpty ifTrue: [^ csBlock value: nil value: nil].
	tuple _ methodRef asString findTokens: ' .'.
	cl _ Smalltalk atOrBelow: tuple first asSymbol ifAbsent: [^ csBlock value: nil value: nil].
	(tuple size = 2 or: [tuple size > 2 and: [(tuple at: 2) ~= 'class']])
		ifTrue: [^ csBlock value: cl value: (tuple at: 2) asSymbol]
		ifFalse: [^ csBlock value: cl class value: (tuple at: 3) asSymbol]