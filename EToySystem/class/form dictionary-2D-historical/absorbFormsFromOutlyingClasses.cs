absorbFormsFromOutlyingClasses
	"EToySystem absorbFormsFromOutlyingClasses"
	| aDict |
	aDict _ self formDictionary.

	#(BadgeMiniPic BadgePic  CoverMain CoverSpiral  CoverTexture ImagiPic  StudioPic WaltPic) do:
		[:sym | aDict at: sym asString put: (EToyWorld classPool at: sym)].

	#(GoPic GoPicOn StepPic StepPicOn StopPic StopPicOn) do:
		[:sym | aDict at: sym asString put: (EToyPlayer classPool at: sym)].

	#(CedarPic CollagePic KayaPic) do:
		[:sym | aDict at: sym asString put: (EToyHolder classPool at: sym)]