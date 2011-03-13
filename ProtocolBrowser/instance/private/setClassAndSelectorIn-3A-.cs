setClassAndSelectorIn: csBlock
	"Decode strings of the form    <selectorName> (<className> [class])"

	| i classAndSelString selString sel |

	sel := self selection ifNil: [^ csBlock value: nil value: nil].
	(sel isKindOf: MethodReference) ifTrue: [
		sel setClassAndSelectorIn: csBlock
	] ifFalse: [
		selString := sel asString.
		i := selString indexOf: $(.
		"Rearrange to  <className> [class] <selectorName> , and use MessageSet"
		classAndSelString := (selString copyFrom: i + 1 to: selString size - 1) , ' ' ,
							(selString copyFrom: 1 to: i - 1) withoutTrailingBlanks.
		MessageSet parse: classAndSelString toClassAndSelector: csBlock.
	].
