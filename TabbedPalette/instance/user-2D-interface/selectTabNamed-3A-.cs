selectTabNamed: aName
	"If the receiver has a tab with the given name, select it"

	| aTab |
	aTab _ self tabNamed: aName.
	aTab ifNotNil: [self selectTab: aTab]