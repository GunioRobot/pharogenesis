replaceGlobalFlapwithID: flapID
	"If there is a global flap with flapID, replace it with an updated one."

	| replacement tabs |
	(tabs := self globalFlapTabsWithID: flapID) size = 0 ifTrue: [^ self].
	tabs do: [:tab |
		self removeFlapTab: tab keepInList: false].
	flapID = 'Pharo' translated ifTrue: [replacement := self newPharoFlap].
	replacement ifNil: [^ self].
	self addGlobalFlap: replacement.
	self currentWorld ifNotNil: [self currentWorld addGlobalFlaps]

"Flaps replaceFlapwithID: 'Widgets' translated "