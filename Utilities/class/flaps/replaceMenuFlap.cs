replaceMenuFlap
	"if there is a global menu flap, replace it with an updated one."

	| aFlapTab |
	aFlapTab _ self globalFlapTabsIfAny detect:
		[:aTab | (aTab submorphs size > 0) and:  [(aTab submorphs first isKindOf: TextMorph) and: [(aTab submorphs first contents string copyWithout: $ ) = 'Menus']]] ifNone: [^ self].
	self removeFlapTab: aFlapTab keepInList: false.
	self addGlobalFlap: self menuFlap.
	Smalltalk isMorphic ifTrue: [World addGlobalFlaps]

"Utilities replaceMenuFlap"