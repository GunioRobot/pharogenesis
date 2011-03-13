classVariablesString
	"Answer a string of my class variable names separated by spaces."

	| aStream |
	aStream _ WriteStream on: (String new: 100).
	self classPool keysDo: [:key | aStream nextPutAll: key; space].
	^aStream contents