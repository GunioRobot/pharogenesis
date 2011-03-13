convertToCurrentVersion: varDict refStream: smartRefStrm
	
	super convertToCurrentVersion: varDict refStream: smartRefStrm.

	"major change - much of AlignmentMorph is now implemented more generally in Morph"
	varDict at: 'hResizing' ifPresent: [ :x | 
		self convertOldAlignmentsNov2000: varDict using: smartRefStrm
	].

