replaceData: newData at: frameNumber
	(kfList last stop = frameNumber) 
		ifTrue:[^self replaceLastData: newData at: frameNumber].
	self halt:'Not implemented yet'