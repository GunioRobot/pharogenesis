initializeForUniverse: aUniverse
	universe _ aUniverse.
	policy _ UPolicy new.
	connectionQueue _ nil.
	connections _ Set new.
