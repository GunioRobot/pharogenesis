fieldList
	object ifNil: [^ Set new].
	^ self baseFieldList
		, (object array
				withIndexCollect: [:each :i | (each notNil and: [each ~= flagObject]) ifTrue: [i printString]])
		  select: [:each | each notNil]