findDuplicates
	"Find duplicate messages, and move the redundant copies to a given category."

	| duplicatesCategory |
	duplicatesCategory _ FillInTheBlank
		request: 'File duplicates in category?'
		initialAnswer: '.duplicates.'.
	duplicatesCategory isEmpty ifTrue:[^ self].

	self requiredCategory: duplicatesCategory.

	Utilities informUser: 'Searching for duplicates...'
		during: [mailDB fileDuplicatesIn: duplicatesCategory].

	self setCategory: duplicatesCategory.
