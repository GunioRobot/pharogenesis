loadDatabase
	| aName aFileStream list |
	aName _ Utilities chooseFileWithSuffixFromList: #('.pda' '.pda.gz' ) withCaption: 'Choose a file to load'.
	aName
		ifNil: [^ self].
	"User made no choice"
	aName == #none
		ifTrue: [^ self inform: 'Sorry, no suitable files found
(names should end with .data or .data.gz)'].
	aFileStream _ FileStream oldFileNamed: aName.
	list _ aFileStream fileInObjectAndCode.
	userCategories _ list first.
	allPeople _ list second.
	allEvents _ list third.
	recurringEvents _ list fourth.
	allToDoItems _ list fifth.
	allNotes _ list sixth.
	date _ Date today.
	self selectCategory: 'all'