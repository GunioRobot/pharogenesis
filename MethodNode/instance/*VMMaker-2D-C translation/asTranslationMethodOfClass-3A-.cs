asTranslationMethodOfClass: aClass
 
	^ aClass new
		setSelector: selectorOrFalse
		args: arguments
		locals: encoder tempsAndBlockArgs
		block: block
		primitive: primitive;
		comment: comment
