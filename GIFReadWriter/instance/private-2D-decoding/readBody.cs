readBody
	"Read the GIF blocks. Modified to return a form.  "

	| form extype block blocksize |
	form _ nil.
	[stream atEnd] whileFalse: [
		block _ self next.
		block = Terminator ifTrue: [^ form].
		block = ImageSeparator ifTrue: [
			form isNil
				ifTrue: [form _ self readBitData]
				ifFalse: [self skipBitData].
		] ifFalse: [
			block = Extension
				ifFalse: [^ form "^ self error: 'Unknown block type'"].
			"Extension block"
			extype _ self next.	"extension type"
			extype = 16rF9 ifTrue: [  "graphics control"
				self next = 4 ifFalse: [^ form "^ self error: 'corrupt GIF file'"].
				self next; next; next.
				transparentIndex _ self next.
				self next = 0 ifFalse: [^ form "^ self error: 'corrupt GIF file'"].
			] ifFalse: [  "Skip blocks"
				[(blocksize _ self next) > 0]
					whileTrue: [self next: blocksize]]]].
