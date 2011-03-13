loadImages2
	"Cut up the CoverMain Image into pieces, so we can move them closer together."

	| aDict mainCover |
	aDict _ self formDictionary.
	mainCover _ aDict at: 'CoverMain'.
	aDict at: 'ImagiPic' put: (ColorForm extent: mainCover width@96 depth: 8).
	mainCover displayOn: (aDict at: 'ImagiPic') at: 0@-4.

	aDict at: 'BadgePic' put: (ColorForm extent: mainCover width@230 depth: 8).
	mainCover displayOn: (aDict at: 'BadgePic') at: 0@-115.

	aDict at: 'StudioPic' put: (ColorForm extent: mainCover width@60 depth: 8).
	mainCover displayOn: (aDict at: 'StudioPic') at: 0@-370.
	(aDict at: 'StudioPic') display