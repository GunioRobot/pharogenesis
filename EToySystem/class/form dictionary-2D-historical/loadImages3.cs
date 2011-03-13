loadImages3
	"Cut up the CoverMain Image into pieces, so we can move them closer together."

	| aDict |
	aDict _ self formDictionary.
	aDict at: 'ImagiPic' put: (GIFReadWriter formFromServerFile: 'updates/19imagi.gif').
	aDict at: 'BadgePic' put: (GIFReadWriter formFromServerFile: 'updates/19badge.gif').
	aDict at: 'StudioPic' put: (GIFReadWriter formFromServerFile: 'updates/19studio.gif').
	aDict at: 'CoverTexture' put: (GIFReadWriter formFromServerFile: 'updates/19texture.gif').

	(aDict at: 'ImagiPic') transparentColor: (Color r: 1.0 g: 0 b: 1.0).
	(aDict at: 'BadgePic') transparentColor: (Color r: 1.0 g: 0 b: 1.0).
	(aDict at: 'StudioPic') transparentColor: (Color r: 1.0 g: 0 b: 1.0).