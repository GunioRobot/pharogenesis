<= aVersion
	^ self packageName = aVersion packageName
		ifFalse: [ self packageName <= aVersion packageName ]
		ifTrue: [ self versionNumber <= aVersion versionNumber ]