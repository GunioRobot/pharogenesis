updateReferencesUsing: aDictionary
	"Fix up the Morphs I own"
	"Note: Update this method when adding new inst vars that could contain Morphs."

	stampButtons _ stampButtons collect:
		[:old | aDictionary at: old ifAbsent: [old]].
	pickupButtons _ pickupButtons collect:
		[:old | aDictionary at: old ifAbsent: [old]].
