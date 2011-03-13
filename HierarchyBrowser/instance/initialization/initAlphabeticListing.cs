initAlphabeticListing
	| tab stab index |
	self systemOrganizer: SystemOrganization.
	metaClassIndicated := false.
	classList := Smalltalk classNames.