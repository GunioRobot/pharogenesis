compileProgrammatically: code classified: cat 

	| oldInitials |
	oldInitials _ Utilities authorInitialsPerSe.
	Utilities setAuthorInitials: 'programmatic'.
	self compile: code classified: cat.
	Utilities setAuthorInitials: oldInitials.
