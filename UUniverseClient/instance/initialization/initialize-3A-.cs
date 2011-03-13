initialize: aUniverse
	universe _ aUniverse.
	
	inMessages _ OrderedCollection new.
	outMessages _ OrderedCollection new.
	
	lastConnectionStart _ DateAndTime epoch.