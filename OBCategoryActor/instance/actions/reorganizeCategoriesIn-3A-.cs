reorganizeCategoriesIn: anOrganizer
	| definition |
	definition _ OBOrganizationDefinition on: anOrganizer.
	definition signalChange.