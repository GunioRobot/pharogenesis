findPreferencesMatching: incomingTextOrString
	"find all preferences matching incomingTextOrString"

	| result aList aPalette controlPage cc |
	result := incomingTextOrString asString asLowercase.
	result := result asLowercase withBlanksTrimmed.
	result isEmptyOrNil ifTrue: [^ self].

	aList := Preferences allPreferenceObjects select:
		[:aPreference | 
			(aPreference name includesSubstring: result caseSensitive: false) or:
				[aPreference helpString includesSubstring: result caseSensitive: false]].
	aPalette := (self containingWindow ifNil: [^ self]) findDeeplyA: TabbedPalette.
	aPalette ifNil: [^ self].
	aPalette selectTabNamed:  'search results'.
	aPalette currentPage ifNil: [^ self].  "bkwd compat"
	controlPage := aPalette currentPage.
	controlPage removeAllMorphs.
	controlPage addMorph: (StringMorph contents: ('Preferences matching "', self searchString, '"') font: Preferences standardButtonFont).
	Preferences alternativeWindowLook ifTrue:[
		cc := Color transparent.
		controlPage color: cc].
	aList := aList asSortedCollection:
		[:a :b | a name < b name].
	aList do:
		[:aPreference | | button |
			button _ aPreference representativeButtonWithColor: cc inPanel: self.
			button ifNotNil: [controlPage addMorphBack: button]].
	aPalette world startSteppingSubmorphsOf: aPalette