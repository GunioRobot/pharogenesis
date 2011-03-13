morphsWelcomeInWorld: aWorld

	^self allInstances anySatisfy: [ :each | each world == aWorld]