asPHOString
	| stream |
	stream _ WriteStream on: String new.
	self do: [ :each | stream nextPutAll: each asPHOString; nextPut: Character cr].
	^ stream contents