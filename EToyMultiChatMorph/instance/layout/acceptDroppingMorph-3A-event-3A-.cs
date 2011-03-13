acceptDroppingMorph: morphToDrop event: evt

	(morphToDrop isKindOf: EToySenderMorph) ifFalse: [
		^morphToDrop rejectDropMorphEvent: evt.
	].
	self eToyRejectDropMorph: morphToDrop event: evt.		"we don't really want it"
	self updateIPAddressField: targetIPAddresses,{morphToDrop ipAddress}.

