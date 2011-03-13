testTwoLevelRequires
	[self noteInterestsForAll.
	self assert: self c4 localSelectors size = 1.
	self assert: self c5 localSelectors size = 1.
	self assert: (self c4 sendCaches selfSendersOf: #blew) = #(#foo ).
	self assert: (self c5 sendCaches selfSendersOf: #blah) = #(#foo ).
	self c4 requiredSelectors.
	self assert: self c4 requirements = (Set withAll: #(#blew )).
	self assert: self c5 requirements = (Set withAll: #(#blah ))]
		ensure: [self loseInterestsInAll ]