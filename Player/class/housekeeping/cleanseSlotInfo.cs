cleanseSlotInfo
	| newInfo |
	slotInfo ifNotNil:
		[newInfo _ IdentityDictionary new.
		slotInfo associationsDo:
			[:assoc | newInfo at: assoc key asSymbol put: assoc value].
		slotInfo _ newInfo]
