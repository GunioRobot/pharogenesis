openAsMorph
	"Create a pluggable version of all the views for a Browser, including views and controllers."
	| window aListExtent next |
	window _ (SystemWindow labelled: 'later') model: self.
	self packages size = 1
		ifTrue: [
			aListExtent _ 0.333333 @ 0.34.
			self systemCategoryListIndex: 1.
			window addMorph: (PluggableListMorph on: self list: #systemCategorySingleton
					selected: #indexIsOne changeSelected: #indexIsOne:
					menu: #packageListMenu:
					keystroke: #packageListKey:from:)
				frame: (0@0 extent: 1.0@0.06).
			next := 0@0.06]
		ifFalse: [
			aListExtent _ 0.25 @ 0.4.
			window addMorph: (PluggableListMorph on: self list: #systemCategoryList
					selected: #systemCategoryListIndex changeSelected: #systemCategoryListIndex:
					menu: #packageListMenu:
					keystroke: #packageListKey:from:)
				frame: (0@0 extent: aListExtent).
			next := aListExtent x @ 0].
	window addMorph: (PluggableListMorph on: self list: #classList
			selected: #classListIndex changeSelected: #classListIndex:
			menu: #classListMenu:
			keystroke: #classListKey:from:)
		frame: (next extent: aListExtent - (0.0 @ 0.05)).
	window addMorph: self buildMorphicSwitches
		frame: (next + (0 @ (aListExtent y - 0.05)) extent: aListExtent x @ 0.05).
	next := next + (aListExtent x @ 0).
	window addMorph: (PluggableListMorph on: self list: #messageCategoryList
			selected: #messageCategoryListIndex changeSelected: #messageCategoryListIndex:
			menu: #messageCategoryMenu:)
		frame: (next extent: aListExtent).
	next := next + (aListExtent x @ 0).
	window addMorph: (PluggableListMorph on: self list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:
			keystroke: #messageListKey:from:)
		frame: (next extent: aListExtent).
	window addMorph: (PluggableTextMorph on: self text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0@0.4 corner: 1@0.94).
	window addMorph: (PluggableTextMorph on: self text: #infoViewContents accept: nil
			readSelection: nil menu: nil)
		frame: (0@0.94 corner: 1@1).
	^ window
