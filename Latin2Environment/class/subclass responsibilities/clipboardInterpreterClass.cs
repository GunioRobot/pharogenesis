clipboardInterpreterClass

	(#('Win32') includes: SmalltalkImage current platformName) 
		ifTrue: [^CP1250ClipboardInterpreter  ].

	^ ISO88592ClipboardInterpreter .
