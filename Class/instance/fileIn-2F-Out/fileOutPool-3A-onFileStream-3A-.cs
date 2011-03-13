fileOutPool: aPool onFileStream: aFileStream 
	| aPoolName |
	aPoolName _ Smalltalk keyAtValue: aPool.
	Transcript cr; show: aPoolName.
	aFileStream nextPutAll: 'Transcript show: ''' , aPoolName , '''; cr!'; cr.
	aFileStream nextPutAll: 'Smalltalk at: #' , aPoolName , ' put: Dictionary new!'; cr.
	aPool asSortedCollection do: [ :anItem | 
		aFileStream nextPutAll: aPoolName , ' at: #' , anItem key asString , ' put:  '.
		(anItem value isKindOf: Number)
			ifTrue: [anItem value printOn: aFileStream]
			ifFalse: [aFileStream nextPutAll: '('.
					anItem value printOn: aFileStream.
					aFileStream nextPutAll: ')'].
		aFileStream nextPutAll: '!'; cr].
	aFileStream cr