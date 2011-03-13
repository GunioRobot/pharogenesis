testTwoLevelRequiresWithUnalignedSuperSendsStartLate
	[self noteInterestsForAll.
	self updateRequiredStatusFor: #x in: self c8.
	self updateRequiredStatusFor: #blah in: self c8.
	self assert: self c8 requirements = (Set with: #blah).
	self updateRequiredStatusFor: #x in: self c7.
	self updateRequiredStatusFor: #blah in: self c7.
	self assert: self c7 requirements = (Set with: #x)]
		ensure: [self loseInterestsInAll]
