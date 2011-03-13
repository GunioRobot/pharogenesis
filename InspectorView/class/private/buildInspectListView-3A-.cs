buildInspectListView: anInspector

	| anInspectListView |

	anInspectListView _ InspectListView new.
	anInspectListView model: anInspector.
	anInspectListView window: (0 @ 0 extent: 40 @ 40).
	anInspectListView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.

	^ anInspectListView