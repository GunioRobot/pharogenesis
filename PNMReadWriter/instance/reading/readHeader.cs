readHeader
	"read header for pbm, pgm or ppm"
	| tokens aux d c  |
	tokens _ OrderedCollection new.
	aux _ self getTokenPbm: tokens.
	cols _ aux at: 1. tokens _ aux at: 2.
	aux _ self getTokenPbm: tokens.
	rows _ aux at: 1. tokens _ aux at: 2.

	(type = 1 or:[type = 4]) ifTrue:[
		maxValue _ 1
	]
	ifFalse: [
		aux _ self getTokenPbm: tokens.
		maxValue _ aux at: 1. tokens _ aux at: 2.
	].
	d _ {1 . 2 . 4 . 	8 . 		16 . 32}.
	c _ {2 . 4 . 16 . 256 . 32768 . 16777216}. 
	(type = 3 or:[type = 6]) ifTrue: [
		maxValue >= 65536 ifTrue:[
			self error:'Pixmap > 48 bits not supported in PPM'
		].
		maxValue >= 256 ifTrue:[
			self error:'Pixmap > 32 bits are not supported in Squeak'
		].
		maxValue < 32 ifTrue:[depth _ 16] ifFalse:[depth _ 32].
	]
	ifFalse: [
		depth _ nil.
		1 to: c size do:[:i| ((c at: i) > maxValue and:[depth = nil]) ifTrue:[depth_d at: i]].
	].
	Transcript cr; show: 'PBM file class ', type asString, ' size ', cols asString, ' x ', 
		rows asString, ' maxValue =', maxValue asString, ' depth=', depth asString.
