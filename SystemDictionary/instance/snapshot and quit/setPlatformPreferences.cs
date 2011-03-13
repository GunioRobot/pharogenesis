setPlatformPreferences
	"Set some platform specific preferences on system startup"
	| platform specs |
	Preferences automaticPlatformSettings ifFalse:[^self].
	platform _ self platformName.
	specs _ 	#(	
					(soundStopWhenDone false)
					(soundQuickStart false)
			).
	platform = 'Win32' ifTrue:[
		specs _ #(	
					(soundStopWhenDone true)
					(soundQuickStart false)
				)].
	platform = 'Mac OS' ifTrue:[
		specs _ #(	
					(soundStopWhenDone false)
					(soundQuickStart true)
				)].
	specs do:[:tuple|
		Preferences setPreference: tuple first toValue: (tuple last == #true).
	].
