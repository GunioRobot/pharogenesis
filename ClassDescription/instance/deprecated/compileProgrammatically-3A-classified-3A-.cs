compileProgrammatically: code classified: cat 
	"compile the given code programmatically.  In the current theory, we always do this unlogged as well, and do not accumulate the change in the current change set"

	self deprecated: 'Use compileSilently:classified: instead.'.
	^ self compileSilently: code classified: cat

"
	| oldInitials |
	oldInitials _ Utilities authorInitialsPerSe.
	Utilities setAuthorInitials: 'programmatic'.
	self compile: code classified: cat.
	Utilities setAuthorInitials: oldInitials.
"