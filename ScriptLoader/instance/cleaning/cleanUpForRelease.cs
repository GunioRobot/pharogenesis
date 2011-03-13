cleanUpForRelease
	"self new cleanUpForRelease"
	
	Author fullName:  'Mr.Cleaner'.
	DataStream initialize.
	Smalltalk cleanUpUndoCommands.
	GradientFillStyle initPixelRampCache.
	NaturalLanguageFormTranslator classPool at: #CachedTranslations put: nil.
	NaturalLanguageTranslator resetCaches.
	FreeTypeCache clearCurrent.
	PaintBoxMorph classPool	at: #ColorChart put: nil.
	PaintBoxMorph classPool at: #Prototype put: nil.
	ImageMorph classPool at: #DefaultForm put: (Form extent: 1@1 depth: 1).
	Utilities classPool at: #ScrapsBook put: nil.
	Project allInstancesDo: [ :each | each setThumbnail: nil ].
	ScriptingSystem stripGraphicsForExternalRelease.
	Smalltalk forgetDoIts.
	ListParagraph initialize.
	PopUpMenu initialize.
	Behavior flushObsoleteSubclasses.
	CommandHistory resetAllHistory.
	CommandHistory allInstancesDo: #initialize.
	ChangeSorter removeChangeSetsNamedSuchThat: [ :each | true ].
	ChangeSet resetCurrentToNewUnnamedChangeSet.
	MethodChangeRecord allInstancesDo: [ :x | x noteNewMethod: nil ].
	RequiredSelectors initialize.
	ProvidedSelectors initialize.
	LocalSends initialize.
	SendCaches initializeAllInstances.
	Utilities cleanseOtherworldlySteppers.
	Smalltalk organization removeEmptyCategories.
	Browser initialize.
	SystemBrowser removeObsolete.
	TheWorldMenu removeObsolete.
	AppRegistry removeObsolete.
	FileServices removeObsolete. 
	MCFileBasedRepository flushAllCaches.
	MCMethodDefinition shutDown.
	MCDefinition clearInstances.
	ChangeSorter initializeChangeSetCategories.
	NaturalLanguageTranslator resetCaches.
	NaturalLanguageTranslator  classPool at: #AllKnownPhrases put: nil.
	Smalltalk at: #TTFontDescription ifPresent: [ :c | c clearDefault; clearDescriptions ].
	ExternalDropHandler resetRegisteredHandlers.
	Undeclared removeUnreferencedKeys.
	Smalltalk flushClassNameCache.
	ScrollBar initializeImagesCache. 
	FreeTypeFontProvider current initialize.
	NaturalLanguageTranslator classPool at: #AllKnownPhrases put: nil.
	StandardScriptingSystem classPool at: #HelpStrings put: IdentityDictionary new.
	FreeTypeFontProvider current initialize.
	SystemNavigation default allObjectsDo: [ :each |
		(each respondsTo: #releaseCachedState) ifTrue: [ each releaseCachedState ] ].	
	3 timesRepeat: [ Smalltalk garbageCollect. Symbol compactSymbolTable ].
	Set rehashAllSets.
	"Remove empty categories, which are not in MC packages, because MC does
	not do this (this script does not make packages dirty)"	
	Smalltalk organization removeEmptyCategories.
	Smalltalk allClassesAndTraitsDo: [ :class |
		[ :each | each removeEmptyCategories; sortCategories.
			] value: class organization; value: class class organization ].
	self cleanUpChanges.
	Smalltalk garbageCollect.
	Author reset.