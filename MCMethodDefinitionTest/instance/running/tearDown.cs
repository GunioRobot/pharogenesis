tearDown
	self restoreMocks.
	self class compile: 'override ^ 1' classified: 'mocks'.
	self ownPackage modified: isModified