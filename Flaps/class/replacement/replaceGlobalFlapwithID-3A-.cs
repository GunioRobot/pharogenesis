replaceGlobalFlapwithID: flapID
	"If there is a global flap with flapID, replace it with an updated one."

	| replacement tabs |
	(tabs _ self globalFlapTabsWithID: flapID) size = 0 ifTrue: [^ self].
	tabs do: [:tab |
		self removeFlapTab: tab keepInList: false].
	flapID = 'Stack Tools' translated ifTrue: [replacement _ self newStackToolsFlap].
	flapID = 'Supplies' translated ifTrue: [replacement _ self newSuppliesFlapFromQuads: 
		(Preferences eToyFriendly
			ifFalse: [self quadsDefiningSuppliesFlap]
			ifTrue: [self quadsDefiningPlugInSuppliesFlap]) positioning: #right].
	flapID = 'Tools' translated ifTrue: [replacement _ self newToolsFlap].
	flapID = 'Widgets' translated ifTrue: [replacement _ self newWidgetsFlap].
	flapID = 'Navigator' translated ifTrue: [replacement _ self newNavigatorFlap].
	flapID = 'Squeak' translated ifTrue: [replacement _ self newSqueakFlap].
	replacement ifNil: [^ self].
	self addGlobalFlap: replacement.
	self currentWorld ifNotNil: [self currentWorld addGlobalFlaps]

"Flaps replaceFlapwithID: 'Widgets' translated "