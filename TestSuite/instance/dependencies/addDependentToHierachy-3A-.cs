addDependentToHierachy: anObject
	self sunitAddDependent: anObject.
	self tests do: [ :each | each addDependentToHierachy: anObject]
			