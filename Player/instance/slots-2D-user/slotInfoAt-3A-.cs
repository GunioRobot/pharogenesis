slotInfoAt: slotName
	| info |
	info _ self slotInfo at: slotName ifAbsent: [nil].
	info ifNil:
		[self slotInfo at: slotName put: (info _ SlotInformation new initialize)].
	(info isKindOf: Symbol) "bkward compat"
		ifTrue:
			[self slotInfo at: slotName put: (info _ SlotInformation new type: info)].
	^ info