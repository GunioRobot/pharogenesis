benchDiffsFrom: before to: afterwards
	"Given two outputs of BitBlt>>benchmark show the relative improvements."
	| old new log oldLine newLine oldVal newVal improvement |
	log _ WriteStream on: String new.
	old _ ReadStream on: before.
	new _ ReadStream on: afterwards.
	[old atEnd or:[new atEnd]] whileFalse:[
		oldLine _ old upTo: Character cr.
		newLine _ new upTo: Character cr.
		(oldLine includes: Character tab) ifTrue:[
			oldLine _ ReadStream on: oldLine.
			newLine _ ReadStream on: newLine.
			Transcript cr; show: (oldLine upTo: Character tab); tab.
			log cr; nextPutAll: (newLine upTo: Character tab); tab.

			[oldLine skipSeparators. newLine skipSeparators.
			oldLine atEnd] whileFalse:[
				oldVal _ Integer readFrom: oldLine.
				newVal _ Integer readFrom: newLine.
				improvement _ oldVal asFloat / newVal asFloat roundTo: 0.01.
				Transcript show: improvement printString; tab; tab.
				log print: improvement; tab; tab].
		] ifFalse:[
			Transcript cr; show: oldLine.
			log cr; nextPutAll: oldLine.
		].
	].
	^log contents