objectAtTab: aName
	"This has to be so contorted!!  The correspondence between names in ONLY stored in the tabs stringButtons contents vs. its first argument!!"

	tabsMorph submorphsDo: [:button |
		button contents = aName ifTrue: [
			^ pages detect: [:p | p externalName = button arguments first] ifNone: [nil]]].
	^ nil