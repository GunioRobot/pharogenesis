test0FixtureIncludeWithIdentityTest
	| element |
	self	shouldnt: [ self collectionWithCopyNonIdentical ]raise: Error.
	element := self collectionWithCopyNonIdentical anyOne.
	self deny: element == element copy.
