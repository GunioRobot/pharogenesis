isAPreferenceViewToKill: aSystemView
	"Answer whether the given StandardSystemView is one affiliated with a PreferencesPanel"

	| m target subView |
	aSystemView subViews size = 1 ifFalse: [^ false].
	subView _ aSystemView subViews first.
	(subView isKindOf: MorphWorldView) ifFalse: [^ false].
	((m _ subView model) isKindOf: MVCWiWPasteUpMorph) ifFalse: [^ false].
	m submorphs size = 1 ifFalse: [^ false].
	m firstSubmorph submorphs size = 1 ifFalse: [^ false].
	target _ m firstSubmorph firstSubmorph. 
	(target isKindOf: TabbedPalette) ifFalse: [^ false].
	^ #(browsing debug fileout general halos) allSatisfy: [:s |
		(target tabNamed: s) notNil]