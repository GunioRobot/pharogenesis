copyAt: anIndex put: anElement
	"Answer a copy of the receiver with anElement inserted at anIndex."

	^ self copyReplaceFrom: anIndex to: anIndex with: (Array with: anElement)