defaultInputInterpreter

	InputInterpreterClass ifNil: [InputInterpreterClass _ self inputInterpreterClass].
	^ InputInterpreterClass new.
