backwardCompatibilityOnly: anExplanationString
	"Warn that the sending method has been deprecated. Methods that are tagt with #backwardCompatibility:
	 are kept for compatibility."

	Preferences showDeprecationWarnings ifTrue:
		[Deprecation signal: thisContext sender printString, ' has been deprecated (but will be kept for compatibility). ', anExplanationString]