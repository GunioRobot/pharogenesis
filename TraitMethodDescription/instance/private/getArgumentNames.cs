getArgumentNames
	| argumentNamesCollection names defaultName |
	defaultName _ 'arg'.
	argumentNamesCollection _ self locatedMethods
		collect: [:each | each argumentNames ].
	names _ Array new: argumentNamesCollection anyOne size.
	argumentNamesCollection do: [:collection |
		1 to: names size do: [:index |
			(names at: index) isNil
				ifTrue: [names at: index put: (collection at: index)]
				ifFalse: [(names at: index) ~= (collection at: index)
					ifTrue: [names at: index put: defaultName, index asString]]]].
	^names
		