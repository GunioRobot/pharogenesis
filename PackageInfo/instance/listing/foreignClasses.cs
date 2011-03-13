foreignClasses
	| s |
	s := IdentitySet new.
	self foreignSystemCategories
		do: [:c | (SystemOrganization listAtCategoryNamed: c)
				do: [:cl | 
					| cls | 
					cls := Smalltalk at: cl. 
					s add: cls;
					  add: cls class]].
	^ s