setUp
	message := ReadWriteStream on: (String new: 10).
	message nextPutAll: 'Hi There!'.