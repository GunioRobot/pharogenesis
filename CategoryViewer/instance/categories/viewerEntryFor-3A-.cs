viewerEntryFor: aViewerRow
	| anEntry |
	anEntry _ ViewerEntry newColumn.
	anEntry addMorphBack: aViewerRow.
	^ anEntry