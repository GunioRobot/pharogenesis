userSlotInformation
	"If the receiver represents a user-defined slot, then return its info; if not, retun nil"
	| aSlotName info |
	((self entryType == #systemSlot) or: [self entryType == #userSlot])
		ifFalse:
			[^ nil].
	aSlotName _ self slotName.
	^ ((info _ self playerBearingCode slotInfo) includesKey: aSlotName)
		ifTrue:
			[info at: aSlotName]
		ifFalse:
			[nil]