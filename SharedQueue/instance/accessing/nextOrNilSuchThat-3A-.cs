nextOrNilSuchThat: aBlock
	"Answer the next object that satisfies aBlock, skipping any intermediate objects.
	If no object has been sent, answer <nil> and leave me intact.
	NOTA BENE:  aBlock MUST NOT contain a non-local return (^)."

	| value readPos |
	accessProtect critical: [
		value _ nil.
		readPos _ readPosition.
		[readPos < writePosition and: [value isNil]] whileTrue: [
			value _ contentsArray at: readPos.
			readPos _ readPos + 1.
			(aBlock value: value) ifTrue: [
				readPosition to: readPos - 1 do: [ :j |
					contentsArray at: j put: nil.
				].
				readPosition _ readPos.
			] ifFalse: [
				value _ nil.
			].
		].
		readPosition >= writePosition ifTrue: [readSynch initSignals].
	].
	^value
"===
q _ SharedQueue new.
1 to: 10 do: [ :i | q nextPut: i].
c _ OrderedCollection new.
[
	v _ q nextOrNilSuchThat: [ :e | e odd].
	v notNil
] whileTrue: [
	c add: {v. q size}
].
{c. q} explore
==="