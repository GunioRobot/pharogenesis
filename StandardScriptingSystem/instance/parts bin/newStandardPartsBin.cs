newStandardPartsBin
	"StandardPartsBin _ nil.  self currentWorld presenter createStandardPartsBin"

	StandardPartsBin ifNil:
		[BookMorph turnOffSoundWhile:
			[StandardPartsBin _ Presenter new newStandardPartsBinTitled: 'objects' includeControls: false]].
	^ StandardPartsBin fullCopy