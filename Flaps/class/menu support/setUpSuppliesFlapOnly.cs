setUpSuppliesFlapOnly
	"Set up the Supplies flap as the only shared flap.  A special version formulated for this stand-alone use is used, defined in #newLoneSuppliesFlap"

	| |
	SharedFlapTabs isEmptyOrNil ifFalse:  "get rid of pre-existing guys if any"
		[SharedFlapTabs do:
			[:t | t referent delete.  t delete]].

	SharedFlapsAllowed := true.
	SharedFlapTabs := OrderedCollection new.
	self enableGlobalFlapWithID: 'Supplies' translated.
	
	ActiveWorld addGlobalFlaps.
	ActiveWorld reformulateUpdatingMenus