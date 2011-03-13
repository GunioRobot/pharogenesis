build
	"ServicePreferences wipe."
	| pr |
	self
		beNotInteractiveDuring: [ServiceProvider registeredProviders
				do: [:p | p registeredServices
						do: [:each | self addService: each provider: p class]].
			pr := ServiceProvider registeredProviders
						gather: [:p | p savedPreferences].
			ServicePreferences replayPreferences: pr.
			].
	ServiceGui updateBars.
	ServiceShortcuts setPreferences