inputInterpreterClass

	(#('Win32') includes: SmalltalkImage current platformName) 
		ifTrue: [^CP1250InputInterpreter ].

	^ ISO88592InputInterpreter.

