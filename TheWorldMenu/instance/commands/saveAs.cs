saveAs
	| name index |
	name := FileDirectory baseNameFor: (FileDirectory default localNameFor: SmalltalkImage current imageName).
	index := name lastIndexOf: FileDirectory extensionDelimiter ifAbsent: [ nil ].
	(index notNil and: [ (name copyFrom: index + 1 to: name size) isAllDigits ])
		ifTrue: [ name := name copyFrom: 1 to: index - 1 ].
	name := FileDirectory default nextNameFor: name extension: FileDirectory imageSuffix.
	name := UIManager default
		request: 'New Image Named:'
		initialAnswer: name.
	name isEmptyOrNil
		ifTrue: [ ^ self ].
	SmalltalkImage current saveAs: name