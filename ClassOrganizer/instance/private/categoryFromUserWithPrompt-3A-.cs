categoryFromUserWithPrompt: aPrompt
	"SystemDictionary organization categoryFromUserWithPrompt: 'testing'"
	| aMenu  |
	aMenu _ CustomMenu new.
	self categories do:
		[:cat | aMenu add: cat asString action: cat].
	^ aMenu startUpWithCaption: aPrompt