remember: anInstance
	AllBlobs isNil ifTrue: [AllBlobs := IdentitySet new].
	^ AllBlobs add: anInstance