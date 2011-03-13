balloonHelpTextForHandle: aHandle 
	"Answer a string providing balloon help for the
	given halo handle"
	| itsSelector |
	itsSelector := aHandle eventHandler firstMouseSelector.
	itsSelector == #doRecolor:with: ifTrue: [^ 'Change color'].
	itsSelector == #mouseDownInDimissHandle:with:
		ifTrue: [^ Preferences preserveTrash
				ifTrue: ['Move to trash']
				ifFalse: ['Remove from screen']].
	#(#(#addFullHandles 'More halo handles') #(#addSimpleHandles 'Fewer halo handles') #(#chooseEmphasisOrAlignment 'Emphasis & alignment') #(#chooseFont 'Change font') #(#chooseNewGraphicFromHalo 'Choose a new graphic') #(#chooseStyle 'Change style') #(#dismiss 'Remove') #(#doDebug:with: 'Debug') #(#doDirection:with: 'Choose forward direction') #(#doDup:with: 'Duplicate')  #(#doMenu:with: 'Menu') #(#doGrab:with: 'Pick up')  #(#editDrawing 'Repaint') #(#mouseDownInCollapseHandle:with: 'Collapse') #(#mouseDownOnHelpHandle: 'Help')  #(#prepareToTrackCenterOfRotation:with: 'Move object or set center of rotation') #(#presentViewMenu 'Present the Viewing menu') #(#startDrag:with: 'Move') #(#startGrow:with: 'Change size') #(#startRot:with: 'Rotate') #(#startScale:with: 'Change scale')#(#trackCenterOfRotation:with: 'Set center of rotation') )
		do: [:pair | itsSelector == pair first
				ifTrue: [^ pair last]].
	^ 'unknown halo handle'translated