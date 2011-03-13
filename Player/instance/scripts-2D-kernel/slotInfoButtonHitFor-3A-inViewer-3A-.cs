slotInfoButtonHitFor: aSlotName inViewer: aViewer
	"The user made a gesture asking for info/menu relating"

	| aMenu slotSym aType |
	slotSym _ aSlotName asSymbol.
	aType _ self typeForSlot: aSlotName asSymbol.
	aMenu _ MenuMorph new defaultTarget: self.
	(#(colorSees copy getNewClone) includes: slotSym) ifFalse:
		[aMenu add: 'simple watcher' selector: #tearOffWatcherFor: argument: slotSym].
	(#(copy getNewClone) includes: slotSym) ifTrue:
		[aMenu add: 'give me a copy now' action: #handTheUserACopy].

	aType == #number "later others" ifTrue:
		[aMenu add: 'detailed watcher' selector: #tearOffFancyWatcherFor: argument: slotSym].

	(self slotInfo includesKey: slotSym)
		ifTrue:  "User slot"
			[aMenu add: 'change data type' selector: #chooseSlotTypeFor: argument: slotSym.
			aType == #number ifTrue:
				[aMenu add: 'decimal places...' selector: #setPrecisionFor: argument: slotSym].
			aMenu add: 'remove "', aSlotName, '"' selector: #removeSlotNamed: argument: slotSym.
			aMenu add: 'rename  "', aSlotName, '"' selector: #renameSlot: argument: slotSym].
	aMenu items size == 0 ifTrue:
		[aMenu add: 'ok' action: #yourself].
	aMenu addTitle: (aSlotName asString, ' (', aType, ')').
	aMenu popUpForHand: aViewer primaryHand in: aViewer world