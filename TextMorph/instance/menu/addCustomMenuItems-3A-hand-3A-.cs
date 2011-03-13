addCustomMenuItems: aCustomMenu hand: aHandMorph
	| outer |
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'add predecessor' action: #addPredecessor:.
	aCustomMenu add: 'add successor' action: #addSuccessor:.
	(Preferences valueOfFlag: #noviceMode) not & 
		(Preferences valueOfFlag: #simpleMenus) not ifTrue: [
			aCustomMenu add: 'code pane menu...' action: #yellowButtonActivity.
			aCustomMenu add: 'code pane shift menu....' action: #shiftedYellowButtonActivity].

	outer _ self owner.
	((outer isKindOf: PolygonMorph) and: [outer isOpen]) ifTrue:
		[container == nil
			ifTrue: [aCustomMenu add: 'follow owner''s curve' action: #followCurve]
			ifFalse: [aCustomMenu add: 'reverse direction' action: #reverseCurveDirection.
					aCustomMenu add: 'set baseline' action: #setCurveBaseline:]]
		ifFalse:
		[(container == nil or: [container fillsOwner not])
			ifTrue: [aCustomMenu add: 'fill owner''s shape' action: #fillingOnOff]
			ifFalse: [aCustomMenu add: 'rectangluar bounds' action: #fillingOnOff].
		(container == nil or: [container avoidsOcclusions not])
			ifTrue: [aCustomMenu add: 'avoid occlusions' action: #occlusionsOnOff]
			ifFalse: [aCustomMenu add: 'ignore occlusions' action: #occlusionsOnOff]].
