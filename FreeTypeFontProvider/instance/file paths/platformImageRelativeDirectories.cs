platformImageRelativeDirectories
	| answer path fontDirectory |
	
	answer := OrderedCollection new.
	(path :=  SmalltalkImage current imagePath)
		ifNotEmpty:[
			(path endsWith: FileDirectory slash) ifFalse:[path := path, FileDirectory slash].
			(fontDirectory := FileDirectory on: path, 'Fonts') exists
				ifTrue:[answer addLast: fontDirectory]].
	^answer