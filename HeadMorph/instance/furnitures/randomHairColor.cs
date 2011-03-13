randomHairColor
	| hairColors |
	hairColors := {Color r: 0.613 g: 0.161 b: 0.0. "red"
		Color r: 0.323 g: 0.226 b: 0.0. "dark brown"
		Color r: 0.774 g: 0.548 b: 0.0. "light brown"
		Color r: 0.968 g: 0.871 b: 0.0. "yellow"
		Color r: 0.581 g: 0.581 b: 0.581. "gray"
		Color black}.
	self submorphs do: [ :each | (hairColors includes: each color) ifTrue: [^ each color]].
	^ hairColors atRandom