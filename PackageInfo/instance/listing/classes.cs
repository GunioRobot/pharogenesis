classes
	^(self systemCategories gather:
		[:cat |
		(SystemOrganization listAtCategoryNamed: cat)
			collect: [:className | Smalltalk at: className]])
				sortBy: [:a :b | a className <= b className]