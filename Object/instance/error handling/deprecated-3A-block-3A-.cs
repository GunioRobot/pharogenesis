deprecated: anExplanationString block: aBlock 
	 "Warn that the sender has been deprecated.  Answer the value of aBlock on resumption.  (Note that #deprecated: is usually the preferred method.)"

	Preferences showDeprecationWarnings ifTrue:
		[Deprecation
			signal: thisContext sender printString, ' has been deprecated. ', anExplanationString].
	^ aBlock value.
