say: x

	(Debug ifNil: [Debug _ OrderedCollection new])
		add: x asString,'
'.
	Debug size > 500 ifTrue: [Debug _ Debug copyFrom: 200 to: Debug size]