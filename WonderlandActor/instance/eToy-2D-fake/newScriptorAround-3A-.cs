newScriptorAround: aPhraseTileMorph
	"Fake, fake, fake."
	| someCamera |
	someCamera _ myWonderland getScene getAllChildren detect:[:any| any isWonderlandCamera].
	^someCamera getMorph assuredPlayer assureUniClass newScriptorAround: aPhraseTileMorph