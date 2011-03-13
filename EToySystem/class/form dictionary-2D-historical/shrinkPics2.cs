shrinkPics2
	"Remove transparent border from source pictures for the front cover.  Adjust offsets to keep the image in the same place on the page."
	" EToySystem new shrinkPics2 "

	| aDict transpVal aForm |
	aDict _ self formDictionary.
	(self formAtKey: 'ImagiPic') depth = 8 ifFalse: [^ self error: 'Pls adjust pixel val for depth'].

	transpVal _ (aForm _ self formAtKey: 'BadgeMiniPic') bits first bitAnd: 255.
	aDict at: 'BadgeMiniPic' put: (aForm trimToPixelValue: transpVal orNot: true)
