additionsToViewerCategoryMiscellaneous
	"Answer viewer additions for the 'miscellaneous' category"

	^#(
		miscellaneous 
		(
			(command doMenuItem: 'do the menu item' Menu)
			(command show 'make the object visible')
			(command hide 'make the object invisible')
			(command wearCostumeOf: 'wear the costume of...' Player)

			(command fire 'trigger any and all of this object''s button actions')
			(slot copy 'returns a copy of this object' Player readOnly Player getNewClone	 unused unused)
			(slot elementNumber 'my index in my container' Number readWrite Player getIndexInOwner Player setIndexInOwner:)
			(slot holder 'the object''s container' Player readOnly Player getHolder Player setHolder:)
			(command stamp 'add my image to the pen trails')
			(command erase 'remove this object from the screen')
			(command stampAndErase 'add my image to the pen trails and go away')
		)
	)

