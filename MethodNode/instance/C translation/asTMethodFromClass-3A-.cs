asTMethodFromClass: aClass
 
	^ TMethod new
		setSelector: selectorOrFalse
		args: arguments
		locals: encoder tempsAndBlockArgs
		block: block
		primitive: primitive
