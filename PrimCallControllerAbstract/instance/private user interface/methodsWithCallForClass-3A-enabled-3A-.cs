methodsWithCallForClass: class enabled: enabledFlag 
	^ class selectors
		collect: [:sel | MethodReference new setStandardClass: class methodSymbol: sel]
		thenSelect: (enabledFlag
				ifNil: [[:mRef | self existsCallIn: mRef]]
				ifNotNil: [enabledFlag
						ifTrue: [[:mRef | self existsEnabledCallIn: mRef]]
						ifFalse: [[:mRef | self existsDisabledCallIn: mRef]]])