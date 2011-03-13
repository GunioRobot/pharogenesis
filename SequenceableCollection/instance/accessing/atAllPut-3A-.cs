atAllPut: anObject 
	"Put anObject at every one of the receiver's indices."
	1 to: self size do:
		[:index | self at: index put: anObject]