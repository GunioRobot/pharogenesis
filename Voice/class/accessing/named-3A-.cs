named: aString
	^ self voices detect: [ :one | one name = aString]