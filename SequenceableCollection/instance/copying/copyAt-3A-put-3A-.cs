copyAt: anIndex put: anElement
	"Answer a copy of the receiver with anElement inserted at anIndex."

	^(self copyFrom: 1 to: anIndex - 1), 
		(Array with: anElement),
		(self copyFrom: anIndex to: self size)