testOneLevelRequires
	
	[self noteInterestsForAll.
	self assert: self c3 localSelectors size = 1.
	self assert: (self c3 sendCaches selfSendersOf: #bla) = #(#foo ).
	self c3 requiredSelectors.
	self assert: self c3 requirements = (Set withAll: #(#bla ))] 
			ensure: [self loseInterestsInAll]