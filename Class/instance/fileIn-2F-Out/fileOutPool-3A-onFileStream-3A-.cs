fileOutPool: aPool onFileStream: aFileStream 
	| aPoolName aValue |
	aPoolName _ Smalltalk keyAtValue: aPool.
	Transcript cr; show: aPoolName.
	aFileStream nextPutAll: 'Transcript show: ''' , aPoolName , '''; cr!'; cr.
	aFileStream nextPutAll: 'Smalltalk at: #' , aPoolName , ' put: Dictionary new!'; cr.
	aPool keys asSortedCollection do: [ :aKey |
		aValue _ aPool at: aKey.
		aFileStream nextPutAll: aPoolName , ' at: #' , aKey asString , ' put:  '.
		(aValue isKindOf: Number)
			ifTrue: [aValue printOn: aFileStream]
			ifFalse: [aFileStream nextPutAll: '('.
					aValue printOn: aFileStream.
					aFileStream nextPutAll: ')'].
		aFileStream nextPutAll: '!'; cr].
	aFileStream cr