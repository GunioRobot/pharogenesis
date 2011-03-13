hideAllPlayers

	| a |
	a _ OrderedCollection new.
	self allMorphsDo: [ :x | 
		(x isKindOf: ViewerFlapTab) ifTrue: [a add: x]
	].
	a do: [ :each | each delete].
