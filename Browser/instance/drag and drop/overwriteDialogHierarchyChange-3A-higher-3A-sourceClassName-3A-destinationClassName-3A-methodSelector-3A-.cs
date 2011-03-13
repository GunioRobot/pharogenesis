overwriteDialogHierarchyChange: hierarchyChange higher: higherFlag sourceClassName: srcClassName destinationClassName: dstClassName methodSelector: methodSelector 
	| lf |
	lf := Character cr asString.
	^ UIManager default
				confirm: 'There is a conflict.' translated, ' Overwrite' translated, (hierarchyChange
							ifTrue: [higherFlag
									ifTrue: [' superclass' translated]
									ifFalse: [' subclass' translated]]
							ifFalse: ['']) , ' method' translated, lf , dstClassName , '>>' , methodSelector , lf , 'by ' translated, (hierarchyChange
							ifTrue: ['moving' translated]
							ifFalse: ['copying' translated]) , ' method' translated, lf , srcClassName name , '>>' , methodSelector , ' ?'.
				
