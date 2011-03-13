buildTrashView: anInspector
	| inspectTrashView |

	inspectTrashView _ StringHolderView new.
	inspectTrashView model: (InspectorTrash for: anInspector object).
	inspectTrashView controller turnLockingOff.
	inspectTrashView window: (0 @ 0 extent: 115 @ 20).
	inspectTrashView borderWidthLeft: 2 right: 2 top: 0 bottom: 2.

	^ inspectTrashView