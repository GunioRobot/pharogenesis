components: anObject
	components _ anObject.
	components do: [ :c | c addDependent:  self ].