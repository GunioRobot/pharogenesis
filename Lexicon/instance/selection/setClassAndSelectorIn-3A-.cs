setClassAndSelectorIn: csBlock
	"Decode strings of the form    <selectorName> (<className> [class])"


	self selection ifNil: [^ csBlock value: targetClass value: nil].
	^ super setClassAndSelectorIn: csBlock