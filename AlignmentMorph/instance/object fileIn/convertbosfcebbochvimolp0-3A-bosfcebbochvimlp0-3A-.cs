convertbosfcebbochvimolp0: varDict bosfcebbochvimlp0: smartRefStrm
	"These variables are automatically stored into the new instance ('bounds' 'owner' 'submorphs' 'fullBounds' 'color' 'extension' 'borderWidth' 'borderColor' 'orientation' 'centering' 'hResizing' 'vResizing' 'inset' 'minCellSize' 'layoutNeeded' 'priorFullBounds' ).
	This method is for additional changes. Use statements like (foo _ varDict at: 'foo')."

		"These are going away ('openToDragNDrop' ).  Possibly store their info in another variable?"

	self enableDragNDrop: (varDict at: 'openToDragNDrop')