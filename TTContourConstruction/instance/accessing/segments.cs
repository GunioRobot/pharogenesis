segments

	| segments |
	segments _ OrderedCollection new.
	self segmentsDo:[:seg| segments add: seg].
	^segments