objectForDataStream: refStrm
	"I am about to be written on an object file.  Write a path to me in the other system instead."

Smalltalk allBehaviorsDo: [:aClass | 
	aClass organization == self ifTrue: [
		(aClass isKindOf: Class) ifTrue: [
			^ DiskProxy global: aClass name selector: #organization args: #()]]].
^ self	"in desparation"
