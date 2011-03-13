infoFor: anElement inViewer: aViewer
	"The user made a gesture asking for info/menu relating"

	| aMenu selector reply elementType |
	elementType _ self elementTypeFor: anElement.
	((elementType = #systemSlot) | (elementType == #userSlot))
		ifTrue:	[^ self slotInfoButtonHitFor: anElement inViewer: aViewer].
	
	self flag: #deferred.  "Use a traditional MenuMorph, and reinstate the pacify thing"
	aMenu _ MVCMenuMorph new.
	aMenu defaultTarget: aMenu.
	(elementType == #userScript)
		ifTrue: 
			[aMenu add: 'destroy "', anElement, '"' selector: #selectMVCItem: argument: #removeScript.
			aMenu add: 'rename  "', anElement, '"' selector: #selectMVCItem: argument:  #renameThisScript.
			aMenu add: 'textual scripting pane'  selector: #selectMVCItem: argument: #makeIsolatedCodePaneFor.
			aMenu add: 'edit balloon help' selector: #selectMVCItem: argument: #editDescription.

			"aMenu add: 'pacify "', anElement, '"' action: #pacifyScript"].
	aMenu items size == 0 ifTrue:
		[aMenu add: 'ok' action: nil].
	aMenu addTitle: anElement asString, ' (', elementType, ')'.
	selector _ anElement asSymbol.
	reply _  aMenu invokeAt: aViewer primaryHand position in: aViewer world.
	reply == nil ifTrue: [^ self].
	reply == #removeScript ifTrue: [^ self removeScript: selector fromWorld: aViewer world].
	reply == #renameThisScript ifTrue: [^ self renameScript:  selector].
	reply == #makeIsolatedCodePaneFor ifTrue: 
		[MethodHolder makeIsolatedCodePaneForClass: self class selector: selector].
	reply == #editDescription ifTrue:
		[(self class userScriptForPlayer: self selector: selector) editDescription.
		self updateAllViewers].
	reply == #pacifyScript ifTrue: [^ self pacifyScript: selector]