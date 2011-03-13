deprecated: aBlock explanation: aString 
	 "This method is OBSOLETE.  Use #deprecated:block: instead."
	self deprecated: 'Use Object>>deprecated:block: instead of deprecated:explanation:.'.

	Preferences showDeprecationWarnings ifTrue:
		[Deprecation
			signal: ('{1} has been deprecated. {2}' translated format: {thisContext sender printString. aString})].
	^ aBlock value.
