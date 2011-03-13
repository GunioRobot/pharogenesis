initialize: universe0
	universe _ universe0.
	universe addDependent: self.

	client _ UUniverseClient forUniverse: universe.
	username _ Utilities authorInitialsPerSe.
	password _ ''.
	
	packageEditors _ Set new.

	selectedPackageIndex _ 0.
