initSounds
	"AbstractSound initSounds"

	Sounds _ Dictionary new.
	(FMSound class organization listAtCategoryNamed: #instruments)
		do: [:sel | Sounds at: sel asString put: (FMSound perform: sel)].
