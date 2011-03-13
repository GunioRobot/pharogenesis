fileOutPool: aPool onFileStream: aFileStream 
	| aPoolName aValue |
	(aPool  isKindOf: SharedPool class) ifTrue:[^self notify: 'we do not fileout SharedPool type shared pools for now'].
	aPoolName := self environment keyAtIdentityValue: aPool.
	Transcript cr; show: aPoolName.
	aFileStream nextPutAll: 'Transcript show: ''' , aPoolName , '''; cr!'; cr.
	aFileStream nextPutAll: 'Smalltalk at: #' , aPoolName , ' put: Dictionary new!'; cr.
	aPool keys asSortedCollection do: [ :aKey |
		aValue := aPool at: aKey.
		aFileStream nextPutAll: aPoolName , ' at: #''' , aKey asString , '''', ' put:  '.
		(aValue isKindOf: Number)
			ifTrue: [aValue printOn: aFileStream]
			ifFalse: [aFileStream nextPutAll: '('.
					aValue printOn: aFileStream.
					aFileStream nextPutAll: ')'].
		aFileStream nextPutAll: '!'; cr].
	aFileStream cr