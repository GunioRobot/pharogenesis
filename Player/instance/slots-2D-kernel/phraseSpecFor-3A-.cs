phraseSpecFor: aPair
	"Expand aPair, whose first element is either #slot or #script, into an array appropriate for mapping into a phrase tile"
	| info prefix |
	info _ (prefix _ aPair first) == #slot
		ifTrue:
			[ScriptingSystem slotInfoFor: aPair second]
		ifFalse:
			[ScriptingSystem scriptInfoFor: aPair second].
	^ (Array with: prefix), info