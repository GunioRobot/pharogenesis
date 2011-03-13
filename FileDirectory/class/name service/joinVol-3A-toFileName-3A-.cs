joinVol: volName toFileName: fileName
	volName isEmpty ifTrue: [^ fileName].
	^ volName , self pathNameDelimiter asString , fileName