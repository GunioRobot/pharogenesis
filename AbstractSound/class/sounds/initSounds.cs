initSounds  "AbstractSound initSounds"
	Sounds _ Dictionary new.
	(FMSound class organization listAtCategoryNamed: #instruments)
		do: [:soundName | Sounds at: soundName asString
						put: (FMSound perform: soundName)]