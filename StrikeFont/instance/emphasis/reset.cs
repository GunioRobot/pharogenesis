reset
	"Reset the cache of derivative emphasized fonts"

	| style font |
	fallbackFont class = FixedFaceFont
		ifTrue: [fallbackFont _ nil].
	derivativeFonts _ Array new: 32.
	#('B' 'I' 'BI') doWithIndex:
		[:tag :index | 
		(style _ TextStyle named: self familyName) ifNotNil:
			[(font _ style fontArray
				detect: [:each | each name = (self name , tag)]
				ifNone: [nil]) ifNotNil: [derivativeFonts at: index put: font]]]