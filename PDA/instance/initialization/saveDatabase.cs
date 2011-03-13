saveDatabase

	(FileStream newFileNamed: (FileDirectory default nextNameFor: 'PDA' extension: 'pda'))
		fileOutClass: nil
		andObject: {userCategories. allPeople. allEvents. recurringEvents. allToDoItems. allNotes}.