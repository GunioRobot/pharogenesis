setNotificationParametersForStandardPreferences
	"Set up the notification parameters for the standard preferences that require need them.  When adding new Preferences that require use of the notification mechanism, users declare the notifcation info as part of the call that adds the preference, or afterwards -- the two relevant methods for doing that are:
 	Preferences.addPreference:categories:default:balloonHelp:projectLocal:changeInformee:changeSelector:   and
	Preference changeInformee:changeSelector:"

		"Preferences setNotificationParametersForStandardPreferences"

	| aPreference |
	#(	
		(annotationPanes		annotationPanesChanged)
		(infiniteUndo			infiniteUndoChanged)
		(optionalButtons			optionalButtonsChanged)
		(roundedWindowCorners	roundedWindowCornersChanged)
		(smartUpdating			smartUpdatingChanged)
		(showSharedFlaps		sharedFlapsSettingChanged)
	)  do:

			[:pair |
				aPreference := self preferenceAt: pair first.
				aPreference changeInformee: self changeSelector: pair second]