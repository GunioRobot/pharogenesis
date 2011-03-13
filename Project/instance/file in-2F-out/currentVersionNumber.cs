currentVersionNumber

	version ifNil: [^0].
	version isInteger ifTrue:[^version].
	version _ Base64MimeConverter decodeInteger: version unescapePercents.
	^version