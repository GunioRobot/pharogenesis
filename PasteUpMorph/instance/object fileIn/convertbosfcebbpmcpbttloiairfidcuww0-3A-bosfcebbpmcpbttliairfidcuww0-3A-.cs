convertbosfcebbpmcpbttloiairfidcuww0: varDict bosfcebbpmcpbttliairfidcuww0: smartRefStrm
	"These variables are automatically stored into the new instance ('bounds' 'owner' 'submorphs' 'fullBounds' 'color' 'extension' 'borderWidth' 'borderColor' 'presenter' 'model' 'cursor' 'padding' 'backgroundMorph' 'turtleTrailsForm' 'turtlePen' 'lastTurtlePositions' 'isPartsBin' 'autoLineLayout' 'indicateCursor' 'resizeToFit' 'fileName' 'isStackLike' 'dataInstances' 'currentDataInstance' 'userFrameRectangle' 'wantsMouseOverHalos' 'worldState' ).
	This method is for additional changes. Use statements like (foo _ varDict at: 'foo')."

		"These are going away ('openToDragNDrop' ).  Possibly store their info in another variable?"

	self enableDragNDrop: (varDict at: 'openToDragNDrop')