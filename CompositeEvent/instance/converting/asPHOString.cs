asPHOString
	| stream |
	stream := WriteStream on: String new.
	self do: [ :each | stream nextPutAll: each asPHOString; nextPut: Character cr].
	^ stream contents