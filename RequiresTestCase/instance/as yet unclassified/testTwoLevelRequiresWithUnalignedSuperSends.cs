testTwoLevelRequiresWithUnalignedSuperSends
	[self noteInterestsForAll.
	self updateRequiredStatusFor: #x in: self c6.
	self updateRequiredStatusFor: #blah in: self c8.
	self assert: self c6 requirements = (Set with: #x).
	self assert: self c7 requirements = (Set with: #x).
	self assert: self c8 requirements = (Set with: #blah).]
		ensure: [self loseInterestsInAll]
