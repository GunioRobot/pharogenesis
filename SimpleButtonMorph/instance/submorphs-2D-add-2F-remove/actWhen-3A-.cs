actWhen: condition
	"Accepts symbols:  #buttonDown, #buttonUp, and #whilePressed, #startDrag"
	actWhen _ condition.
	actWhen == #startDrag
		ifFalse: [self on: #startDrag send: nil to: nil ]
		ifTrue:[self on: #startDrag send: #doButtonAction to: self].