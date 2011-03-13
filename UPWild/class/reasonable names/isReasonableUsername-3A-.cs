isReasonableUsername: aString
	^aString isEmpty not and: [ aString allSatisfy: [ :c | c isAlphaNumeric ] ]