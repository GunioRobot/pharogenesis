convertToCurrentVersion: varDict refStream: smartRefStrm

	| newish |
	newish _ super convertToCurrentVersion: varDict refStream:
smartRefStrm.

	"major change - much of AlignmentMorph is now implemented
more generally in Morph"
	varDict at: 'hResizing' ifPresent: [ :x |
		^ newish convertOldAlignmentsNov2000: varDict using:
smartRefStrm].
	^ newish
