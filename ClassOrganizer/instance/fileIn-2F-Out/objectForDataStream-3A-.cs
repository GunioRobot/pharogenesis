objectForDataStream: refStrm
	| dp |
	"I am about to be written on an object file.  Write a path to me in the other system instead."

Smalltalk allBehaviorsDo: [:aClass | 
	aClass organization == self ifTrue: [
		(refStrm insideASegment and: [aClass isSystemDefined not]) ifTrue: [
			^ self].	"do trace me"
		(aClass isKindOf: Class) ifTrue: [
			dp _ DiskProxy global: aClass name selector: #organization args: #().
			refStrm replace: self with: dp.
			^ dp]]].
^ self	"in desparation"
