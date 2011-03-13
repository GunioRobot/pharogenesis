changeSound: upDown
	| ind arg st soundChoices index it current |
	"move in the list of sounds.  Adjust arg tile after me"

	ind _ owner submorphs indexOf: self.
	arg _ owner submorphs atWrap: ind+1.
	arg isSyntaxMorph ifFalse: [^ self].
	st _ arg submorphs detect: [:mm | mm isKindOf: StringMorph] ifNone: [^ self].
	soundChoices _ #('silence').  "default, if no SampledSound class"
	Smalltalk at: #SampledSound ifPresent:
		[:sampledSound | soundChoices _ sampledSound soundNames].
	current _ st contents copyFrom: 2 to: st contents size-1.	"remove string quotes"
	index _ soundChoices indexOf: current.
	index > 0 ifTrue:
		[st contents: (it _ soundChoices atWrap: index + upDown) printString.
		self playSoundNamed: it].
