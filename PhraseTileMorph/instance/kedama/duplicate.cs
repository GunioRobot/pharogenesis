duplicate
	"Make and return a duplicate of the receiver."

	| newMorph |
	newMorph := super duplicate.
	(self ownerThatIsA: Viewer) ifNotNilDo:
		[:aViewer | newMorph replacePlayerInReadoutWith: aViewer scriptedPlayer].

	^ newMorph