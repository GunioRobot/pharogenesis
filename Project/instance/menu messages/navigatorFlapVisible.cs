navigatorFlapVisible
	"Answer whether a Navigator flap is visible"

	^ (Flaps sharedFlapsAllowed and: 
		[self flapsSuppressed not]) and:
			[self isFlapIDEnabled: 'Navigator' translated]