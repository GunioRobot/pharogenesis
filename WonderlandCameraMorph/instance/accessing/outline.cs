outline
	^ outline ifNil:[outline _ ReadWriteStream on: #()]