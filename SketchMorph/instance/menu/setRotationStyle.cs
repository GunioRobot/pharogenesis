setRotationStyle

	| menu newStyle |
	menu _ CustomMenu new.
	#('rotate smoothly' 'left-right flip only' 'top-down flip only' 'don''t rotate')
		with: #(normal leftRight upDown none)
		 do: [:name :action | menu add: name action: action].
	newStyle _ menu startUp.
	newStyle ifNotNil: [self rotationStyle: newStyle].
