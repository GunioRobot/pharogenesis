mergeDatabase

	| aName aFileStream list |
	aName _ Utilities chooseFileWithSuffixFromList: #('.pda' '.pda.gz')
		withCaption: 'Choose a file to load'.
	aName ifNil: [^ self].  "User made no choice"
	aName == #none ifTrue: [^ self inform: 
'Sorry, no suitable files found
(names should end with .data or .data.gz)'].

	aFileStream _ FileStream oldFileNamed: aName.

	list _ aFileStream fileInObjectAndCode.
	userCategories _ ((list at: 1) , userCategories) asSet asArray sort.
	allPeople _ ((list at: 2) , allPeople) asSet asArray sort.
	allEvents _ ((list at: 3) , allEvents) asSet asArray sort.
	recurringEvents _ ((list at: 4) , recurringEvents) asSet asArray sort.
	allToDoItems _ ((list at: 5) , allToDoItems) asSet asArray sort.
	allNotes _ ((list at: 6) , allNotes) asSet asArray sort.
	date _ Date today.
	self selectCategory: 'all'.
