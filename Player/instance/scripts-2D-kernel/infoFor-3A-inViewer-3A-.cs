infoFor: anElement inViewer: aViewer
	"The user made a gesture asking for info/menu relating"

	| aMenu selector reply elementType |
	elementType _ self elementTypeFor: anElement.
	((elementType = #systemSlot) | (elementType == #userSlot))
		ifTrue:	[^ self slotInfoButtonHitFor: anElement inViewer: aViewer].
	
	self flag: #deferred.  "Use a traditional MenuMorph, and reinstate the pacify thing"
	aMenu _ MVCMenuMorph new.
	(elementType == #userScript)
		ifTrue: 
			[aMenu add: 'destroy "', anElement, '"' action: #removeScript.
			aMenu add: 'rename  "', anElement, '"' action: #renameScript.
			"aMenu add: 'pacify "', anElement, '"' action: #pacifyScript"].
	aMenu items size == 0 ifTrue:
		[aMenu add: 'ok' action: nil].
	aMenu addTitle: anElement asString, ' (', elementType, ')'.
	selector _ anElement asSymbol.
	reply _  aMenu invokeAt: aViewer primaryHand position in: aViewer world.
	reply == nil ifTrue: [^ self].
	reply == #removeScript ifTrue: [^ self removeScript: selector].
	reply == #renameScript ifTrue: [^ self renameScript:  selector].
	reply == #pacifyScript ifTrue: [^ self pacifyScript: selector]