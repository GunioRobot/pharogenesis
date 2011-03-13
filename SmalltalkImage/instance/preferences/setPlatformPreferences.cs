setPlatformPreferences
	"Set some platform specific preferences on system startup"
	| platform specs |
	Preferences automaticPlatformSettings ifFalse:[^self].
	platform := self platformName.
	specs := 	#(	
					(soundStopWhenDone false)
					(soundQuickStart false)
			).
	platform = 'Win32' ifTrue:[
		specs := #(	
					(soundStopWhenDone true)
					(soundQuickStart false)
				)].
	platform = 'Mac OS' ifTrue:[
		specs := #(	
					(soundStopWhenDone false)
					(soundQuickStart true)
				)].
	specs do:[:tuple|
		Preferences setPreference: tuple first toValue: (tuple last == true).
	].
