deleteAllPreferencesPanels
	"Called manually to clobber all existing preferences panels"
	"PreferencesPanel deleteAllPreferencesPanels"

	| aWindow |
	self allInstancesDo:
		[:aPanel |
			(aWindow _ aPanel containingWindow) isMorph
				ifTrue:
					[aWindow delete]].
	self killExistingMVCViews.
	UpdatingThreePhaseButtonMorph allInstancesDo: "clobber old stand-alone prefs buttons"
		[:m | (m actionSelector == #togglePreference:) ifTrue:
			[(m owner isAlignmentMorph) ifTrue:
				[m owner delete]]]