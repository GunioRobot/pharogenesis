testBrowseHierarchyMataclass
	"self debug: #testBrowseHierarchyMataclass"
	| browsersBefore browsersAfter opened |
	self ensureMorphic.
	
	browsersBefore := self currentHierarchyBrowsers.
	1 class class browseHierarchy.
	browsersAfter := self currentHierarchyBrowsers.
	
	self assert:  (browsersAfter size  = (browsersBefore size + 1)).
	opened := browsersAfter removeAll: browsersBefore; yourself.
	self assert:  (opened size = 1).
	opened := opened asArray first.
	self assert: (opened model selectedClass == Metaclass).
	
	opened delete
	
	
	