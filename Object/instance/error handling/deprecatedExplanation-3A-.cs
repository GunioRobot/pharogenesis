deprecatedExplanation: aString
     "This method is OBSOLETE.  Use #deprecated: instead."
	self deprecated: 'Use Object>>deprecated: instead of deprecatedExplanation:.'.

	Preferences showDeprecationWarnings ifTrue:
		[Deprecation signal: ('{1} has been deprecated. {2}' translated format: {thisContext sender printString. aString})]