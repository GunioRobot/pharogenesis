changeOffsetTo: aPoint

	| transform trialOffset innerPasteup keepWidth keepHeight |

	transform _ self myTransformMorph.
	keepWidth _ transform width "// 4".
	keepHeight _ transform height "// 4".
	innerPasteup _ transform firstSubmorph.
	trialOffset _ aPoint.
	trialOffset _ 
		(trialOffset x 
			min: (innerPasteup width * transform scale) - keepWidth 
			max: keepWidth - transform width) @ 
		(trialOffset y 
			min: (innerPasteup height * transform scale) - keepHeight 
			max: keepHeight - transform height).
	transform offset: trialOffset.

