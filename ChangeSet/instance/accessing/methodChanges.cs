methodChanges

	| methodChangeDict changeTypes |
	methodChangeDict := Dictionary new.
	changeRecords associationsDo:
		[:assn |
		changeTypes := assn value methodChangeTypes.
		changeTypes isEmpty ifFalse: [methodChangeDict at: assn key put: changeTypes]].
	^ methodChangeDict