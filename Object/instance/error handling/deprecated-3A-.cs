deprecated: anExplanationString
	"Warn that the sending method has been deprecated."

	Preferences showDeprecationWarnings ifTrue:
		[Deprecation signal: thisContext sender printString, ' has been deprecated. ', anExplanationString]