buildCodeView: anInspector
	| inspectCodeView |

	inspectCodeView _ InspectCodeView new.
	inspectCodeView model: anInspector.
	inspectCodeView window: (0 @ 0 extent: 75 @ 40).
	inspectCodeView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	^ inspectCodeView