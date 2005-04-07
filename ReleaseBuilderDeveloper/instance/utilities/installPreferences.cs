installPreferences
	super installPreferences.
	#(
		(updateFromServerAtStartup true)

	) do:[:spec|
		Preferences setPreference: spec first toValue: spec last]