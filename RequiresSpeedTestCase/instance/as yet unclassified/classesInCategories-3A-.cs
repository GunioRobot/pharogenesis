classesInCategories: currentCats 
	^currentCats gather: 
					[:c | 
					(SystemOrganization listAtCategoryNamed: c) 
						collect: [:name | Smalltalk at: name]]