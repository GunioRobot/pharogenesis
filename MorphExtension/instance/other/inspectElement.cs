inspectElement
	"Create and schedule an Inspector on the otherProperties and the 
	named properties."
	| key obj |
	key _ (SelectionMenu selections: self sortedPropertyNames)
				startUpWithCaption: 'Inspect which property?'.
	key
		ifNil: [^ self].
	obj _ self otherProperties
				at: key
				ifAbsent: ['nOT a vALuE'].
	obj = 'nOT a vALuE'
		ifTrue: [(self perform: key) inspect
			"named properties"]
		ifFalse: [obj inspect]