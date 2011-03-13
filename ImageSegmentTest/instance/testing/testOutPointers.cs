testOutPointers
	"self debug: #testOutPointers"

	| segment external internal root |
	external := Object new.
	internal := true -> external.
	root := false -> internal.
	internal := nil.
	
	segment := self createSegmentFrom: root.

	self assert: segment outPointers size = 3.
	self assert: [ segment outPointers includesAllOf: {external. true. false} ].