printWhileOn: aMorph indent: level

	(arguments first isJust: NodeNil) ifTrue: [
		selector _ SelectorNode new
			key: (selector key == #whileTrue:
				ifTrue: [#whileTrue] ifFalse: [#whileFalse])
			code: #macro.
		arguments _ Array new
	].
	self printKeywords: selector key arguments: arguments
		on: aMorph indent: level