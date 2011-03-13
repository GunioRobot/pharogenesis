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
		(doDebug:with:							'Debug')
		(doDirection:with:						'Choose forward direction')
		(doDup:with:							'Duplicate')
		(doMenu:with:							'Menu')
		(doGrab:with:							'Pick up')
		(doRecolor:with:							'Change color')
		(editButtonsScript						'See the script for this button')
		(editDrawing							'Repaint')
		(maybeDoDup:with:						'Duplicate')
		(makeNascentScript						'Make a scratch script')
		(makeNewDrawingWithin				'Paint new object')
		(mouseDownInCollapseHandle:with:		'Collapse morph')
		(mouseDownOnHelpHandle:				'Help')
		(openViewerForArgument				'Open a Viewer for me')
		(paintBackground						'Paint background')
		(prepareToTrackCenterOfRotation:with:	'Set center of rotation')
		(presentViewMenu						'Present the Viewing menu')
		(startDrag:with:							'Move')
		(startGrow:with:							'Change size') 
		(startRot:with:							'Rotate')
		(startScale:with:							'Change scale') 
		(tearOffTile								'Make a tile representing this object')
		(trackCenterOfRotation:with:				'Set center of rotation')) 


	do:
		[:pair | itsSelector == pair first ifTrue: [^ pair last]].

	(itsSelector == #mouseDownInDimissHandle:with:) ifTrue:
		[^ Preferences preserveTrash
			ifTrue:
				['Move to trash']
			ifFalse:
				['Remove from screen']].

	^ 'unknown halo handle'