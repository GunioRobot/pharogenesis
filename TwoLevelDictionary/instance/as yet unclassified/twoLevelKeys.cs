twoLevelKeys

	| twoLevelSet |

	twoLevelSet _ TwoLevelSet new.
	self keysDo: [ :each | twoLevelSet add: each].
	^twoLevelSet
