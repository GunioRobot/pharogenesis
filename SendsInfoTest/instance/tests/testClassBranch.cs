testClassBranch
	self assert: #classBranch sends: #(tell shouldnt:raise:) supersends: #() classSends: #(tell).
	self classBranch.