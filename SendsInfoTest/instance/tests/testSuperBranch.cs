testSuperBranch
	self assert: #superBranch sends: #(tell should:raise:) supersends: #(tell) classSends: #().
	self superBranch.