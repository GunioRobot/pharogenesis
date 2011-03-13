buttonWithSelector: aSelector
	"If receiver has a control button with the given action selector answer it, else answer nil.  morphic only at this point"

	| aWindow aPane |
	((aWindow _ self containingWindow) isKindOf: SystemWindow) ifFalse: [^ nil].
	(aPane _ aWindow submorphNamed: 'buttonPane') ifNil: [^ nil].
	^  aPane submorphThat: [:m | (m isKindOf: PluggableButtonMorph) and:
		[m actionSelector == aSelector]] ifNone: [^ nil]