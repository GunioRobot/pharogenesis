findPreference: evt
	"Allow the user to submit a selector fragment; search for that among preference names; put up a list of qualifying preferences; if the user selects one of those, redirect the preferences panel to reveal the chosen preference"

	| result aList aPalette controlPage |
	result _ FillInTheBlank request: 'Search for preferences containing:' initialAnswer: 'color'.
	result _ result asLowercase copyWithout: $ .
	result isEmptyOrNil ifTrue: [^ self].

	aList _ Preferences allPreferenceFlagKeys select:
		[:aKey | 
			aKey includesSubstring: result caseSensitive: false].
	aPalette _ self containingWindow findDeeplyA: TabbedPalette.
	aPalette ifNil: [^ self].
	aPalette selectTabNamed:  'search results'.
	aPalette currentPage ifNil: [^ self].  "bkwd compat"
	controlPage _ aPalette currentPage.
	controlPage removeAllMorphs.
	aList do:
		[:aPrefSymbol |
			controlPage addMorphBack: (Preferences
								buttonRepresenting: aPrefSymbol
								wording: aPrefSymbol
								color: nil)].
	aPalette world startSteppingSubmorphsOf: aPalette.
"
	result _ (SelectionMenu selections: aList) startUpWithCaption: 'Choose which Preference you want to find'.
	Preferences factoredCategories do:
		[:aCategoryPair |
			(aCategoryPair second includes: result)
				ifTrue:
					[^ self switchToCategoryNamed: aCategoryPair first event: evt]]"