systemConverterClass

	(#('Win32') includes: SmalltalkImage current platformName) 
		ifTrue: [^CP1250TextConverter ].

	^ ISO88592TextConverter.
