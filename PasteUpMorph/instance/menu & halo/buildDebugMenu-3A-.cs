buildDebugMenu: aHandMorph
	| aMenu |
	aMenu _ super buildDebugMenu: aHandMorph.
	aMenu add:  'abandon costume history' translated target: self action: #abandonCostumeHistory.
	^ aMenu