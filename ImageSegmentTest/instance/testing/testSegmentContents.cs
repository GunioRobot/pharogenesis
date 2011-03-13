testSegmentContents
	"self debug: #testSegmentContents"

	| segment contents external internal root |
	external := Object new.
	internal := true -> external.
	root := false -> internal.
	internal := nil.
	
	segment := self createSegmentFrom: root.
	contents := self analyzeSegment: segment.
	
	"segment should contain the root array, root, and internal -- but not external"
	self assert: contents size = 3.
	self assert: [ (contents collect: #first) includesAllOf: #(Array Association Association) ].