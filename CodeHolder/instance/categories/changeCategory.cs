changeCategory
	"Present a menu of the categories of messages for the current class, and let the user choose a new category for the current message"

	| aClass aSelector |
	(aClass _ self selectedClassOrMetaClass) ifNotNil:
		[(aSelector _ self selectedMessageName) ifNotNil:
			[(aClass organization letUserReclassify: aSelector) ifTrue:
				["Smalltalk changes reorganizeClass: aClass."
				"Decided on further review that the above, when present, could cause more
                    unexpected harm than good"
				self methodCategoryChanged]]]