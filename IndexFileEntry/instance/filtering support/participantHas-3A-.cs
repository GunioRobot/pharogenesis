participantHas: stringOrList

	^ (self field: from has: stringOrList) or:
	   [(self field: self to has: stringOrList) or:
	   [self field: self cc has: stringOrList]]