mergeDatabase
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
	userCategories _ (list first , userCategories) asSet asArray sort.
	allPeople _ (list second , allPeople) asSet asArray sort.
	allEvents _ (list third , allEvents) asSet asArray sort.
	recurringEvents _ (list fourth , recurringEvents) asSet asArray sort.
	allToDoItems _ (list fifth , allToDoItems) asSet asArray sort.
	allNotes _ ((list sixth)
				, allNotes) asSet asArray sort.
	date _ Date today.
	self selectCategory: 'all'