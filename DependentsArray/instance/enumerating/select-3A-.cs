select: aBlock 
	"Refer to the comment in Collection|select:."
	| aStream |
	aStream := (self species new: self size) writeStream.
	self do:[:obj|
		(aBlock value: obj)
			ifTrue: [aStream nextPut: obj]].
	^ aStream contents