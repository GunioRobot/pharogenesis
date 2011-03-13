/ aNumber 
	"Primitive. Answer the result of dividing receiver by aNumber.
	Fail if the argument is not a Float. Essential. See Object documentation
	whatIsAPrimitive."

	<primitive: 50>
	aNumber = 0.0 ifTrue: [ ZeroDivide signalWithDividend: self].
	^aNumber adaptToFloat: self andSend: #/