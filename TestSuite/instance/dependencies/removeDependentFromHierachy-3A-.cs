removeDependentFromHierachy: anObject
	self sunitRemoveDependent: anObject.
	self tests do: [ :each | each removeDependentFromHierachy: anObject]
			