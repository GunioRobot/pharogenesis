balloonHelpTextForHandle: aHandle
	"Answer a string providing balloon help for the given halo handle"

	|  itsSelector |
	itsSelector _ aHandle eventHandler firstMouseSelector.
	#(	(addFullHandles							'More halo handles')
		(addSimpleHandles						'Fewer halo handles')
		(chooseEmphasisOrAlignment				'Emphasis & alignment')
		(chooseFont								'Change font')
		(chooseNewGraphicFromHalo				'Choose a new graphic')
		(chooseStyle								'Change style')
		(dismiss									'Remove')
		(doDebug:with:							'Debug (press shift to inspect morph)')
		(doDirection:with:						'Choose forward direction')
		(doDup:with:							'Duplicate')
		(doDupOrMakeSibling:with: 				'Duplicate (press shift to make a sibling)')
		(doMakeSiblingOrDup:with: 				'Make a sibling (press shift to make simple duplicate)')
		(doMakeSibling:with: 					'Make a sibling')
		(doMenu:with:							'Menu')
		(doGrab:with:							'Pick up')
		(editButtonsScript						'See the script for this button')
		(editDrawing							'Repaint')
		(maybeDoDup:with:						'Duplicate')
		(makeNascentScript						'Make a scratch script')
		(makeNewDrawingWithin				'Paint new object')
		(mouseDownInCollapseHandle:with:		'Collapse')
		(mouseDownOnHelpHandle:				'Help')
		(openViewerForArgument				'Open a Viewer for me')
		(openViewerForTarget:with:				'Open a Viewer for me')
		(paintBackground						'Paint background')
		(prepareToTrackCenterOfRotation:with:	'Move object or set center of rotation')
		(presentViewMenu						'Present the Viewing menu')
		(startDrag:with:							'Move')
		(startGrow:with:							'Change size (press shift to preserve aspect)') 
		(startRot:with:							'Rotate')
		(startScale:with:							'Change scale') 
		(tearOffTile								'Make a tile representing this object')
		(tearOffTileForTarget:with:				'Make a tile representing this object')
		(trackCenterOfRotation:with:				'Set center of rotation')) 


	do:
		[:pair | itsSelector == pair first ifTrue: [^ pair last]].

	(itsSelector == #mouseDownInDimissHandle:with:) ifTrue:
		[^ Preferences preserveTrash
			ifTrue:
				['Move to trash']
			ifFalse:
				['Remove from screen']].

	(itsSelector == #doRecolor:with:) ifTrue: [
		^ Preferences propertySheetFromHalo
			ifTrue: ['Property Sheet (press shift for simple recolor)']
			ifFalse: ['Change color (press shift for more properties)']].

	^ 'unknown halo handle'