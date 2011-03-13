defaultSized: aNumber
	| fonts f |
	"This used to be the default textstyle, but it needs to be a StrikeFont and not a TTCFont and sometimes the default textstyle is a TTCFont.  So, we use a typical StrikeFont as the default fallback font."
	fonts := (TextConstants at: #Accuny) fontArray.
	f := fonts first.
	1 to: fonts size do: [:i |
		aNumber > (fonts at: i) height ifTrue: [f _ fonts at: i].
	].
	^f
