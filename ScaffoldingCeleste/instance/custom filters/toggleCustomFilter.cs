toggleCustomFilter
	| name |
	codeFilter ifNil: [
		name := self selectFilterFrom: self customFilterNames.
		name ifNil: [ ^self ].
		codeFilter := NamedFilters at: name.
	] ifNotNil: [
		codeFilter := nil.
	].
	
	self filtersChanged.

