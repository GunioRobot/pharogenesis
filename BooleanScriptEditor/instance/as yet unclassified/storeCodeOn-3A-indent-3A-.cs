storeCodeOn: aStream indent: tabCount

	((submorphs size > 0) and:
	 [submorphs first submorphs size > 0]) ifTrue: [
			aStream nextPutAll: '(('.
			super storeCodeOn: aStream indent: tabCount.
			aStream nextPutAll: ') ~~ false)'.
			^ self].
	aStream nextPutAll: ' true '.
