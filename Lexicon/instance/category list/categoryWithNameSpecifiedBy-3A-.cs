categoryWithNameSpecifiedBy: aSelector
	"Answer the category name obtained by sending aSelector to my class.  This provides a way to avoid hard-coding the wording of conventions such as '-- all --'"

	^ self class perform: aSelector