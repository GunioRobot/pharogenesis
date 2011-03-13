category
	"Answer the system organization category for the receiver. First check whether the
	category name stored in the ivar is still correct and only if this fails look it up
	(latter is much more expensive)"

	| result |
	self basicCategory ifNotNilDo: [ :symbol |
		((SystemOrganization listAtCategoryNamed: symbol) includes: self name)
			ifTrue: [ ^symbol ] ].
	self basicCategory: (result := SystemOrganization categoryOfElement: self name).
	^result