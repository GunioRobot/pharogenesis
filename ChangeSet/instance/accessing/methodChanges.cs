methodChanges

	| methodChangeDict changeTypes |
	methodChangeDict _ Dictionary new.
	changeRecords associationsDo:
		[:assn |
		changeTypes _ assn value methodChangeTypes.
		changeTypes isEmpty ifFalse: [methodChangeDict at: assn key put: changeTypes]].
	^ methodChangeDict