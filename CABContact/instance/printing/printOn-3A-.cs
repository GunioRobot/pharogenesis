printOn: aStream 
	aStream nextPutAll: firstName;
		 nextPutAll: ' '.
	aStream nextPutAll: lastName.
	email
		ifNotNil: [aStream nextPutAll: ' Email: ';
				 nextPutAll: email].
	nickname
		ifNotNil: [aStream nextPutAll: ' Nickname:v';
				 nextPutAll: nickname].
	aStream nextPutAll: ' Frequency: ';
				 nextPutAll: (frequency asString).