saveAsCustomPartsBin
	| aBin |
	self closeEditing.
	labelString = 'Standard Parts' ifTrue: [self setLabel: 'Custom Parts'].
	aBin _ self veryDeepCopy.

	ScriptingSystem setCustomPartsBinFrom: aBin.
	self inform: 
'Okay; from now on, when you request
''custom parts bin'' from the ''authoring tools...''
menu, you will obtain a copy of this parts bin'