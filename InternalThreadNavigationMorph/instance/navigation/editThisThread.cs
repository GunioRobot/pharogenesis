editThisThread

	| sorter |

	sorter _ ProjectSorterMorph new.
	sorter navigator: self listOfPages: listOfPages.
	self currentWorld addMorphFront: sorter.
	sorter align: sorter center with: self currentWorld center.
	self delete.

