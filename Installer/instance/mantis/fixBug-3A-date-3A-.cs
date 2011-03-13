fixBug: aBugNo date: aDate

	self setBug: aBugNo.
	
 	self install: self maUrl from: self maScript.
	
	self maCheckDateAgainst: aDate.
	
	
	
