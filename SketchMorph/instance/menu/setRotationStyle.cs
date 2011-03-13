setRotationStyle
	| selections labels sel reply |
	selections _ #(normal leftRight upDown none).
	labels _ #('rotate smoothly' 'left-right flip only' 'top-down flip only' 'don''t rotate').
	sel _ labels at: (selections indexOf: self rotationStyle ifAbsent:[1]).
	labels _ labels collect:[:lbl| sel = lbl ifTrue:['<on>',lbl] ifFalse:['<off>',lbl]].
	reply _ (SelectionMenu labelList: labels selections: selections) startUp.
	reply ifNotNil: [self rotationStyle: reply].
