findOwnersOutPtrs

| ow ff |
ow _ Smalltalk at: #Owners ifAbsent: [^ self].
ow ifNil: [^ self].
outPointers do: [:oo | 
	oo isMorph ifTrue: [
		ow _ ow copyReplaceAll: oo printString with: oo printString, '[<<<- Pointed at]']].
ff _ FileStream fileNamed: 'Owners log'.
ff nextPutAll: ow; close.
Smalltalk at: #Owners put: ow.
ff edit.