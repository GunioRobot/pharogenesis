nextImage
	"Read in the next xbm image from the stream."
	| form long incount chunks byteWidth pad fourway outcount total |
	stream reset.
	stream ascii.
	self readHeader.
	form _ ColorForm extent: width@height depth: 1.
	incount _ 0.	outcount _1.
	chunks _ Array new: 4.	byteWidth _ width + 7 // 8.
	total _ byteWidth * height.
	byteWidth > 4
		ifTrue: [ pad _ byteWidth \\ 4]
		ifFalse: [ pad _ 4 - byteWidth ].
	fourway _ 0.
	[(incount = total)] whileFalse: [
		incount _ incount + 1.
		fourway _ fourway + 1.
		chunks at: fourway put: (Flipbits at: ((self parseByteValue) +1)).
		(pad > 0 and: [(incount \\ byteWidth) = 0]) ifTrue: [
			1 to: pad do:
				[:q |	
  			fourway _ fourway + 1.	
			chunks at: fourway put: 0]
		].
		fourway = 4 ifTrue: [
			long _ Integer
				byte1: (chunks at: 4)
				byte2: (chunks at: 3)
				byte3: (chunks at: 2)
				byte4: (chunks at: 1).
			(form bits) at: outcount put: long.
			fourway _ 0.
			outcount _ outcount + 1].
		].
	 ^ form 