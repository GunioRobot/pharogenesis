debuggingMenuFor: aHandMorph
	| aMenu |
	aMenu _ super debuggingMenuFor: aHandMorph.
	aMenu add:  'abandon costume history' target: self action: #abandonCostumeHistory.
	^ aMenu