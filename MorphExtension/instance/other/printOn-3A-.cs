printOn: aStream
	super printOn: aStream.
	aStream nextPutAll: ' ', self identityHashPrintString.
	locked == true ifTrue: [aStream nextPutAll: ' [locked] '].
	visible == false ifTrue: [aStream nextPutAll: '[not visible] '].
	sticky == true ifTrue: [aStream nextPutAll: ' [sticky] '].
	balloonText ifNotNil: [aStream nextPutAll: ' [balloonText] '].
	balloonTextSelector ifNotNil: [aStream nextPutAll: ' [balloonTextSelector: ', balloonTextSelector printString, '] '].
	externalName ifNotNil: [aStream nextPutAll: ' [externalName = ', externalName, ' ] '].
	isPartsDonor == true ifTrue: [aStream nextPutAll: ' [isPartsDonor] '].
	player ifNotNil: [aStream nextPutAll: ' [player = ', player printString, '] '].
	eventHandler ifNotNil: [aStream nextPutAll: ' [eventHandler = ', eventHandler printString, '] '].
	otherProperties isEmptyOrNil ifTrue: [^ self].

	aStream nextPutAll: ' [other: '.
	otherProperties keysDo: [:aKey | aStream nextPutAll: ' (', aKey, ' -> ', (otherProperties at: aKey) printString, ')'].
	aStream nextPut: $]