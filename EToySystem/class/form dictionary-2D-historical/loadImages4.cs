loadImages4
	"Read in the pieces of the cover picture"

	| aDict |
	aDict _ self formDictionary.
	aDict at: 'ImagiPic' put: (GIFReadWriter formFromServerFile: 'updates/19imagi.gif').
	aDict at: 'BadgePic' put: (GIFReadWriter formFromServerFile: 'updates/19badge.gif').
	aDict at: 'StudioPic' put: (GIFReadWriter formFromServerFile: 'updates/19studio.gif').
	aDict at: 'CoverTexture' put: (GIFReadWriter formFromServerFile: 'updates/19texture.gif').
	aDict at: 'BadgeMiniPic' put: (GIFReadWriter formFromServerFile: 'updates/19badgeMini.gif')
