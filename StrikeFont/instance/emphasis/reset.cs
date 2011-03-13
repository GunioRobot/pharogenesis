reset
	"Reset the cache of derivative emphasized fonts"
	fallbackFont class = FixedFaceFont ifTrue: [ fallbackFont := nil ].
	derivativeFonts notNil ifTrue: 
		[ derivativeFonts withIndexDo: 
			[ :f :i | 
			(f notNil and: [ f isSynthetic ]) ifTrue: 
				[ derivativeFonts 
					at: i
					put: nil ] ] ]
	"
	derivativeFonts _ Array new: 32.
	#('B' 'I' 'BI') doWithIndex:
		[:tag :index | 
		(style _ TextStyle named: self familyName) ifNotNil:
			[(font _ style fontArray
				detect: [:each | each name = (self name , tag)]
				ifNone: [nil]) ifNotNil: [derivativeFonts at: index put: font]]]
	"