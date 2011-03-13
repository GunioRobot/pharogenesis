systemConverterClass

	(#('Win32') includes: SmalltalkImage current platformName) 
		ifTrue: [^CP1253TextConverter ].

	^ ISO88597TextConverter.
