addCustomMenuItems: aCustomMenu hand: aHandMorph 
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addUpdating: #snapshotBackgroundString action: #toggleSnapshotBackground.
	aCustomMenu addUpdating: #getDragAndDropState action: #toggleDragAndDropState.
	(myControls == nil)
		
		ifTrue:[aCustomMenu add: 'showCameraControls' action: #showCameraControls]
ifFalse:[aCustomMenu add: 'hideCameraControls' action: #deleteCameraControls]
		
	
