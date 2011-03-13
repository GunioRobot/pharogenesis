additionsToViewerCategories
	"Answer viewer additions for the 'layout' category"

	^#((
		layout 
		(
			(slot cellInset 'The cell inset' Number readWrite Player getCellInset Player setCellInset:)
			(slot layoutInset 'The layout inset' Number readWrite Player getLayoutInset Player setLayoutInset:)
			(slot listCentering 'The list centering' ListCentering readWrite Player getListCentering Player setListCentering:)
			(slot hResizing  	'Horizontal resizing' Resizing readWrite Player 	getHResizing Player setHResizing:)
			(slot vResizing  	'Vertical resizing' Resizing readWrite Player 	getVResizing Player setVResizing:)
			(slot listDirection  'List direction' ListDirection readWrite Player 	getListDirection Player setListDirection:)
			(slot wrapDirection 'Wrap direction' ListDirection readWrite Player 	getWrapDirection Player setWrapDirection:)
		)))
