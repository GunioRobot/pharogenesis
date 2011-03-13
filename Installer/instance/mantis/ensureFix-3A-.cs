ensureFix: aBugNo

	| fixesAppliedNumbers |
	
	self setBug: aBugNo.
	
	fixesAppliedNumbers := self class fixesApplied collect: [ :fixDesc | fixDesc asInteger ].
	
	(fixesAppliedNumbers includes: bug) ifFalse: [ self fixBug: aBugNo ]