clause: aClause
	clause _ aClause.
	clause phrases do: [ :each | each accept: self].
	phrase _ word _ syllable _ nil