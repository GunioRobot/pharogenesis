removeCategory
	"Remove the current category"

	| itsName |
	self changeSetCategory acceptsManualAdditions ifFalse:
		[^ self inform: 'sorry, you can only remove manually-added categories.'].

	(self confirm: 'Really remove the change-set-category
named ', (itsName := changeSetCategory categoryName), '?') ifFalse: [^ self].

	self changeSetCategories removeElementAt: itsName.
	self setDefaultChangeSetCategory.

	self update