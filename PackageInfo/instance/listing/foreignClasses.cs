foreignClasses
	| s |
	s _ IdentitySet new.
	self foreignSystemCategories
		do: [:c | (SystemOrganization listAtCategoryNamed: c)
				do: [:cl | 
					| cls | 
					cls _ Smalltalk at: cl. 
					s add: cls;
					  add: cls class]].
	^ s