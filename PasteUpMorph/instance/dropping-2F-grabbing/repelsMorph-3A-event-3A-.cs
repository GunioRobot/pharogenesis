repelsMorph: aMorph event: ev
	isPartsBin == true ifTrue: [^ true].
	openToDragNDrop ifFalse: [^ true].
	(self wantsDroppedMorph: aMorph event: ev) ifFalse: [^ true].
	^ super repelsMorph: aMorph event: ev "consults #repelling flag"