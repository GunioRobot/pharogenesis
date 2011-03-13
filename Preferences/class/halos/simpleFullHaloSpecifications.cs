simpleFullHaloSpecifications
	"This method gives the specs for the 'full' handles variant when simple halos are in effect"

	"Preferences resetHaloSpecifications"

	^ #(
	"  	selector				horiz		vert			color info						icon key
		---------				------		-----------		-------------------------------		---------------"
	(addDebugHandle:		right		topCenter		(blue	veryMuchLighter)		'Halo-Debug')
	(addDismissHandle:		left			top				(red		muchLighter)			'Halo-Dismiss')
	(addRotateHandle:		left			bottom			(blue)							'Halo-Rot')
	(addMenuHandle:		leftCenter	top				(red)							'Halo-Menu')
	(addGrabHandle:			center		top				(black)							'Halo-Grab')
	(addDragHandle:			rightCenter	top				(brown)							'Halo-Drag')
	(addDupHandle:			right		top				(green)							'Halo-Dup')	
	(addHelpHandle:			center		bottom			(lightBlue)						'Halo-Help')
	(addGrowHandle:		right		bottom			(yellow)						'Halo-Scale')
	(addScaleHandle:		right		bottom			(lightOrange)					'Halo-Scale')
	(addFewerHandlesHandle:	left		topCenter		(paleBuff)						'Halo-FewerHandles')
	(addRepaintHandle:		right		center			(lightGray)						'Halo-Paint')
	(addFontSizeHandle:		leftCenter	bottom			(lightGreen)						'Halo-FontSize')
	(addFontStyleHandle:		center		bottom			(lightRed)						'Halo-FontStyle')
	(addFontEmphHandle:	rightCenter	bottom			(lightBrown darker)		  'Halo-FontEmph')
	(addRecolorHandle:		right		bottomCenter	(magenta darker)				'Halo-Recolor')

		) 