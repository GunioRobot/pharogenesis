loadDatabase

	| aName aFileStream list |
	aName _ Utilities chooseFileWithSuffixFromList: #('.pda' '.pda.gz')
		withCaption: 'Choose a file to load'.
	aName ifNil: [^ self].  "User made no choice"
	aName == #none ifTrue: [^ self inform: 
'Sorry, no suitable files found
(names should end with .data or .data.gz)'].

	aFileStream _ FileStream oldFileNamed: aName.

	list _ aFileStream fileInObjectAndCode.
	userCategories _ list at: 1.
	allPeople _ list at: 2.
	allEvents _ list at: 3.
	recurringEvents _ list at: 4.
	allToDoItems _ list at: 5.
	allNotes _ list at: 6.
	date _ Date today.
	self selectCategory: 'all'.
