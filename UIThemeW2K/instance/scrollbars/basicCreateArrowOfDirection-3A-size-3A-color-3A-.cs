basicCreateArrowOfDirection: aSymbol size: finalSizeInteger color: aColor 
	
	| form |
	form := Form extent: finalSizeInteger asPoint depth: Display depth.
	form fillColor: Color transparent.
	
	aSymbol == #right 
		ifTrue: [self drawRightArrowIn: form boundingBox on: form getCanvas. ].
	aSymbol == #bottom 
		ifTrue: [self drawDownArrowIn: form boundingBox on: form getCanvas. ].
	aSymbol == #left 
		ifTrue: [self drawLeftArrowIn: form boundingBox on: form getCanvas. ].
	aSymbol == #top
		ifTrue: [self drawUpArrowIn: form boundingBox on: form getCanvas. ].
		
	^form copy: (form boundingBox insetBy: 3)