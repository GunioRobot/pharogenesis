initialize
	"Preferences initialize"
	"Sometimes placed in a change-set even though unchanged, to trigger reinitialization upon update."

	FlagDictionary _ Dictionary new.
	self chooseInitialSettings.
