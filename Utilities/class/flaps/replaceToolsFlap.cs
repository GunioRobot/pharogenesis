replaceToolsFlap
	"if there is a global tools flap, replace it with an updated one."

	| aFlapTab |
	aFlapTab _ self globalFlapTabsIfAny detect:
		[:aTab | (aTab submorphs size > 0) and:  [(aTab submorphs first isKindOf: TextMorph) and: [(aTab submorphs first contents string copyWithout: Character cr) = 'Tools']]] ifNone: [^ self].
	self removeFlapTab: aFlapTab keepInList: false.
	self addGlobalFlap: self standardRightFlap.
	self currentWorld ifNotNil: [self currentWorld addGlobalFlaps]

"Utilities replaceToolsFlap"