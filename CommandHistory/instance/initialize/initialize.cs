initialize
	super initialize.
	lastCommand := nil.
	history := OrderedCollection new.
	excursions := OrderedCollection new.