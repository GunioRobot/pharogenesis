setUpSuppliesFlapOnly
	"Set up the Supplies flap as the only shared flap.  A special version formulated for this stand-alone use is used, defined in #newLoneSuppliesFlap"

	| supplies |
	SharedFlapTabs isEmptyOrNil ifFalse:  "get rid of pre-existing guys if any"
		[SharedFlapTabs do:
			[:t | t referent delete.  t delete]].

	SharedFlapsAllowed _ true.
	SharedFlapTabs _ OrderedCollection new.
	SharedFlapTabs add: (supplies _ self newLoneSuppliesFlap).
	self enableGlobalFlapWithID: 'Supplies' translated.
	supplies setToPopOutOnMouseOver: false.

	Smalltalk isMorphic ifTrue:
		[ActiveWorld addGlobalFlaps.
		ActiveWorld reformulateUpdatingMenus]