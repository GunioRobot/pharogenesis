isReasonablePackageName: aString
	^aString allSatisfy: [ :c | c isAlphaNumeric or: [ ' -.' includes: c ]]