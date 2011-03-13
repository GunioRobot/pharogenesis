removeHyperSqueakFromSystem
	"Remove all the HyperSqueak classes from the system.  9/18/96 sw"

	| hsSupport |
	(hsSupport _ self hyperSqueakSupportClass) == nil
		ifTrue:
			[^ self inform: 'HyperSqueak is already gone!'].
	hsSupport squeakCategories do:
		[:aCategoryName | SystemOrganization removeSystemCategory: aCategoryName]