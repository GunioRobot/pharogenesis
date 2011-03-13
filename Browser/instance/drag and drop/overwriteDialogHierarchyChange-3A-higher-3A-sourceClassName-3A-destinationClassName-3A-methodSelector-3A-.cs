overwriteDialogHierarchyChange: hierarchyChange higher: higherFlag sourceClassName: srcClassName destinationClassName: dstClassName methodSelector: methodSelector 
	| lf success |
	lf := Character cr asString.
	success := SelectionMenu
				confirm: 'There is a conflict.' , ' Overwrite' , (hierarchyChange
							ifTrue: [higherFlag
									ifTrue: [' superclass']
									ifFalse: [' subclass']]
							ifFalse: ['']) , ' method' , lf , dstClassName , '>>' , methodSelector , lf , 'by ' , (hierarchyChange
							ifTrue: ['moving']
							ifFalse: ['copying']) , ' method' , lf , srcClassName name , '>>' , methodSelector , ' ?'
				trueChoice: 'Yes, don''t care.'
				falseChoice: 'No, I have changed my opinion.'.
	^ success