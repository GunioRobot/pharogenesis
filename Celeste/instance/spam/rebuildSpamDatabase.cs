rebuildSpamDatabase
	mailDB ifNil: [^ self].
	mailDB rebuildSpamDatabase.