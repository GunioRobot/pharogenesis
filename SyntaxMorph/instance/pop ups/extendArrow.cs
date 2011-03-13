extendArrow
	"Return the extend arrow button.  It replaces the argument with a new message.
	I am a number or getter messageNode."
	| patch ok sel ss |
	
	ok _ false.
	(self nodeClassIs: LiteralNode) ifTrue: [
		[self decompile asString asNumber] ifError: [:msg :rcvr | ^ nil].
		ok _ true].
	(self nodeClassIs: MessageNode) ifTrue: [
		ss _ submorphs select: [:mm | mm isSyntaxMorph].
		ss size > 1 ifTrue: [
			(ss second nodeClassIs: SelectorNode) ifTrue: [
				((sel _ ss second decompile asString) beginsWith: 'get') ifTrue: [
					ok _ (sel atWrap: 4) isUppercase ]]]].	"a getter -- hope it is a number"

	ok ifFalse: [^ nil].
	patch _ (ImageMorph new image: (TileMorph classPool at: #SuffixPicture)).
	patch on: #mouseDown send: #extend to: self.
	^ patch