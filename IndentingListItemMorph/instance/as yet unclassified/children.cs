children
	| children |
	children _ OrderedCollection new.
	self childrenDo: [:each | children add: each].
	^children