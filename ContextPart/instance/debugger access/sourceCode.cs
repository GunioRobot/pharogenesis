sourceCode
	| mclass code |
	Sensor leftShiftDown ifFalse:
		[code _ self method getSource.
		code isNil ifFalse: [^ code]].
	mclass _ self receiver class selectorAtMethod: self method setClass: [:c | c].
	^ (self receiver class decompilerClass new
		decompile: mclass
		in: self receiver class
		method: self method) decompileString