testBrowseInstance
	"self debug: #testBrowseInstance"
	| browsersBefore browsersAfter opened |
	self ensureMorphic.
	
	browsersBefore := self currentBrowsers.
	1 browse.
	browsersAfter := self currentBrowsers.
	
	self assert:  (browsersAfter size  = (browsersBefore size + 1)).
	opened := browsersAfter removeAll: browsersBefore; yourself.
	self assert:  (opened size = 1).
	opened := opened asArray first.
	self assert: (opened model selectedClass == SmallInteger).
	
	opened delete
	
	
	