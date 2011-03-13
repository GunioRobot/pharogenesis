clause: aClause
	clause := aClause.
	clause phrases do: [ :each | each accept: self].
	phrase := word := syllable := nil