orphanedHelpEntries
	"Answer a list of all the keys in the help dictionary that are not represented by actual preferences"

	^ HelpDictionary keys asSortedArray copyWithoutAll: self allPreferenceFlagKeys

"Preferences orphanedHelpEntries"