deprecated: anExplanationString
	"Warn that the sending method has been deprecated."

	(Deprecation
		method: thisContext sender method
		explanation: anExplanationString
		on: nil
		in: nil) signal