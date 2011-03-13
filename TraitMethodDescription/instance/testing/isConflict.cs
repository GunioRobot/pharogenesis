isConflict
	| count |
	count _ 0.
	self methodsDo: [:each |
		each isProvided ifTrue: [
			count _ count + 1.
			count > 1 ifTrue: [^true]]].
	^false