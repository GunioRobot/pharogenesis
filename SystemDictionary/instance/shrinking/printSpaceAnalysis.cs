printSpaceAnalysis	"Smalltalk garbageCollect; printSpaceAnalysis"
	"Note: this all needs to be updated for 32-bit direct pointers"
	| f name space scale count instSpace |
	f _ FileStream newFileNamed: 'STspace.text'.
	f timeStamp.
	f nextPutAll: 'class'; tab;
			nextPutAll: 'space'; tab;
			nextPutAll: '#insts'; tab;
			nextPutAll: 'inst space'; tab.
	self allClassesDo:
		[:cl | name _ cl name forceTo: 30 paddingWith: Character space.
		space _ cl space.
		count _ cl instanceCount.
		instSpace _ (cl instSize+4)*count.
		cl isVariable ifTrue:
				[scale _ cl isBytes ifTrue: [4] ifFalse: [1].
				cl allInstancesDo: [:x | instSpace _ instSpace + (x size//scale)]].
		f nextPutAll: name; tab;
			print: space; tab;
			print: count; tab;
			print: instSpace; cr].
	f close