slotInfoButtonHitFor: aSlotName inViewer: aViewer
	"The user made a gesture asking for info/menu relating"
	| aMenu slotSym aType |
	slotSym _ aSlotName asSymbol.
	aType _ self typeForSlot: aSlotName asSymbol.
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu add: 'simple watcher' selector: #tearOffWatcherFor: argument: slotSym.
	aType == #number "later others" ifTrue:
		[aMenu add: 'fancier watcher' selector: #tearOffFancyWatcherFor: argument: slotSym].

	(self slotInfo includesKey: slotSym)
		ifTrue:  "User slot"
			[aMenu add: 'change data type' selector: #chooseSlotTypeFor: argument: slotSym.
			aType == #number ifTrue:
				[aMenu add: 'decimal places...' selector: #setPrecisionFor: argument: slotSym].
			aMenu add: 'remove "', aSlotName, '"' selector: #removeSlotNamed: argument: slotSym.
			aMenu add: 'rename  "', aSlotName, '"' selector: #renameSlot: argument: slotSym].
	aMenu items size == 0 ifTrue:
		[aMenu add: 'ok' action: nil].
	aMenu addTitle: (aSlotName asString, ' (', aType, ')').
	aMenu popUpForHand: aViewer primaryHand