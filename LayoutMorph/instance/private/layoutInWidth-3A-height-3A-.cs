layoutInWidth: w height: h
	"Adjust the size of the receiver in its space-filling dimensions during layout. This message is sent to only to layout submorphs."

	((hResizing = #spaceFill) and: [bounds width ~= w]) ifTrue: [
		bounds _ bounds origin extent: (w @ bounds height).
		fullBounds _ nil.
		layoutNeeded _ true].

	((vResizing = #spaceFill) and: [bounds height ~= h]) ifTrue: [
		bounds _ bounds origin extent: (bounds width @ h).
		fullBounds _ nil.
		layoutNeeded _ true].
