widgetNamed: aString
	self name = aString
		ifTrue: [^ self]
		ifFalse: [children do: [:ea | (ea widgetNamed: aString) ifNotNil: [:w | ^ w]]].
	^ nil