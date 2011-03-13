buildScheduledView: anInspector
	"This is old code referred to in benchmarks - may be deleted"
	| anInspectorView topView |
	anInspectorView _ self inspector: anInspector.
	topView _ StandardSystemView new.
	topView model: anInspector.
	topView addSubView: anInspectorView.
	topView label: anInspector object class name.
	topView minimumSize: 180 @ 120.
	^topView