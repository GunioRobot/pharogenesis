select: aBlock 
	"Refer to the comment in Collection|select:."
	| aStream |
	aStream _ WriteStream on: (self species new: self size).
	self do:[:obj|
		(aBlock value: obj)
			ifTrue: [aStream nextPut: obj]].
	^ aStream contents