sizeCodeForStore: encoder
	self reserve: encoder.
	(key isVariableBinding and: [key isSpecialWriteBinding]) ifFalse:
		[^encoder sizeStoreLiteralVar: index].
	code < 0 ifTrue:
		[self flag: #dubious.
		 self code: (self code: self index type: LdLitType)].
	"THIS IS WRONG!! THE VALUE IS LOST FROM THE STACK!!
	 The various value: methods on Association ReadOnlyVariableBinding
	 etc _do not_ return the value assigned; they return the receiver."
	"Should generate something more like
		push expr
		push lit
		push temp (index of expr)
		send value:
		pop"
	self flag: #bogus.
	writeNode := encoder encodeSelector: #value:.
	^(encoder sizePushLiteralVar: index)
	 + (writeNode sizeCode: encoder args: 1 super: false)