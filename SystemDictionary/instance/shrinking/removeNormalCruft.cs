removeNormalCruft
	"Remove various graphics, uniclasses, references. Caution: see
	comment at bottom of method"
	"Smalltalk removeNormalCruft"
	ScriptingSystem stripGraphicsForExternalRelease.
	References keys
		do: [:k | References removeKey: k].
	self classNames
		do: [:cName | #('Player' 'CardPlayer' 'Component' 'WonderlandActor' 'MorphicModel' 'PlayWithMe' )
				do: [:superName | ((cName ~= superName
								and: [cName beginsWith: superName])
							and: [(cName allButFirst: superName size)
									allSatisfy: [:ch | ch isDigit]])
						ifTrue: [self removeClassNamed: cName]]].
	self
		at: #Wonderland
		ifPresent: [:cls | cls removeActorPrototypesFromSystem].
	ChangeSet current clear
	"Caution: if any worlds in the image happen to have uniclass
	players associated with them, running this method would
	likely compromise their functioning and could cause errors,
	especially if the uniclass player of the current world had any
	scripts set to ticking. If that happens to you somehow, you will
	probably want to find a way to reset the offending world's
	player to be an UnscriptedCardPlayer, or perhaps nil"