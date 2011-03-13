stripGraphicsForExternalRelease
	"EToySystem stripGraphicsForExternalRelease"

	| aDict replacement |
	aDict _ ScriptingSystem formDictionary.
	replacement _ aDict at: 'Gets'.

	#('BadgeMiniPic' 'BadgePic' 'Broom' 'CedarPic' 'CollagePic' 'CoverMain' 'CoverSpiral' 'CoverTexture' 'Fred' 'ImagiPic' 'KayaPic' 'StudioPic')
		do:
			[:aKey | aDict at: aKey put: replacement]