updateDisplayContents 
	"Refer to the comment in StringHolderView|updateDisplayContents."

	| contents |
	contents _ model contents.
	displayContents asString ~= contents
		ifTrue: 
			[model messageListIndex ~= 0
				ifTrue: [contents _ contents asText
								makeSelectorBoldIn: model selectedClassOrMetaClass].
			self editString: contents.
			self displayView.
			model editSelection == #newMessage ifTrue:
				[controller selectFrom: 1 to: contents size]]