renameCategoryFrom: oldName to: newName
	"Rename the category currently known by oldName to be newName.  No senders at present but once a UI is establshed for renaming categories, this will be useful."

	| aCategory |
	(aCategory _ self categoryAt: oldName) ifNil: [^ self].
	aCategory categoryName: newName