initializeSystemSlotDictionary
	"ScriptingSystem initializeSystemSlotDictionary"
	SystemSlotDictionary _ IdentityDictionary new.
	StandardSlotInfo keysDo:
		[:aKey |
			SystemSlotDictionary at: aKey put: (StandardSlotInfo at: aKey) second]