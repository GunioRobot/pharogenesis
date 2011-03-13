shrinkPics
	"Remove transparent border from source pictures for the front cover.  Adjust offsets to keep the image in the same place on the page."
	" EToySystem shrinkPics "

	| offset oldW rect transpVal aDict aForm |
	aDict _ self formDictionary.
	(aDict at: 'ImagiPic') depth = 8 ifFalse: [^ self error: 'Pls adjust pixel val for depth'].
	transpVal _ (aForm _ aDict at: 'CoverSpiral') bits first bitAnd: 255.	"pixelValueAt: goes through the map, and lies"
	offset _ (aForm innerPixelRectFor: transpVal orNot: true) topLeft.
	aDict at: 'CoverSpiral' put: (aForm trimToPixelValue: transpVal orNot: true).

	oldW _ (aForm _ aDict at: 'ImagiPic') width.
	transpVal _ aForm bits first bitAnd: 255.
	rect _ (aForm innerPixelRectFor: transpVal orNot: true).
	aDict at: 'ImagiPic' put: (aForm trimToPixelValue: transpVal orNot: true).

	oldW _ (aForm _ aDict at: 'BadgePic') width.
	transpVal _ aForm bits first bitAnd: 255.
	rect _ (aForm innerPixelRectFor: transpVal orNot: true).
	aDict at: 'BadgePic' put: (aForm trimToPixelValue: transpVal orNot: true).

	oldW _ (aForm _ aDict at: 'StudioPic') width.
	transpVal _ aForm bits first bitAnd: 255.
	rect _ (aForm innerPixelRectFor: transpVal orNot: true).
	aDict at: 'StudioPic' put: (aForm trimToPixelValue: transpVal orNot: true)
