name

	^ envtName ifNil: ['Environment ' , self hash printString]