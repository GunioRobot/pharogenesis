isAcceptablePlayerSlotName: aSymbol
	"Answer whether the given symbol is a suitable slot name for a player.  It is assumed to be a well-formed inst-var-name already.  No senders at the moment, because the current UI always corrects the input into an acceptable name.  But could return"

	self noOtherSenders: #isAcceptablePlayerSlotName:.  "keeps this from getting mentally garbage-collected"

	(SystemSlotDictionary includesKey: aSymbol) ifTrue: [^ false].
	(ReservedScriptNames includes: aSymbol) ifTrue: [^ false].

	(#(costume costumes dependents true false size) includes: aSymbol) ifTrue: [^ false].
	^ true