makeNihongoImage

	"self makeNihongoImage"
	Utilities emptyScrapsBook.

	Display setExtent: 960@720 depth: 16.
	World color: (Color r: 0.935 g: 0.935 b: 0.935).

	Preferences takanawa.
	Preferences setPreference: #magicHalos toValue: false.
	Preferences setPreference: #magicHalos toValue: true.
	Preferences setPreference: #mouseOverHalos toValue: false.
	Preferences setPreference: #mouseOverHalos toValue: true.

	Player abandonUnnecessaryUniclasses.
	Player freeUnreferencedSubclasses.
	Player removeUninstantiatedSubclassesSilently.

	PartsBin initialize.
	Flaps disableGlobalFlaps: false.
	Flaps addAndEnableEToyFlaps.
	ActiveWorld addGlobalFlaps.
	Flaps sharedFlapsAlongBottom.

	Locale currentPlatform: (Locale isoLanguage: 'ja').
	Locale switchToID: (LocaleID isoLanguage: 'ja').
	Preferences restoreDefaultFonts.
	StrikeFont setupDefaultFallbackFont.
	Project current updateLocaleDependents.

	"Dump all projects"
	Project allSubInstancesDo:[:prj| prj == Project current ifFalse:[Project deletingProject: prj]].

	ChangeSet current clear.
	ChangeSet current name: 'Unnamed1'.
	Smalltalk garbageCollect.


