tokens

	| separators type |
	tokens ifNil:
		[separators _ Character separators.
		tokens _ OrderedCollection new.

		"first tokenize the header"
		fields keysAndValuesDo:
			[ :fieldName :fieldValues |
			fieldValues do:
				[ :fieldValue |
				tokens addAll: (fieldValue asHeaderValue findTokens: separators)]].

		"then tokenize parts of the body that are text"
		separators _ separators, '!.,:;"<>()'. 
		body parts isEmpty
			ifTrue:
				[tokens addAll: (body content findTokens: separators)]
			ifFalse:
				[body parts do:
					[:part |
					type _ part fieldNamed: 'content-type' ifAbsent: [nil].
					(type isNil or: [type mainValue beginsWith: 'text']) ifTrue:
						[tokens addAll: (part body content findTokens: separators)]]]].
	"get rid of any extra long tokens"
	tokens _ tokens reject: [:t | t size > 40].
	^ tokens

