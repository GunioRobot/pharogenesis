recordGradientFill: fillIndex matrix: gradientMatrix ramp: colorRampArray linear: aBoolean
	| fillStyle ramp origin direction normal |
	ramp := colorRampArray collect:[:assoc| (assoc key / 255.0) -> assoc value].
	origin := gradientMatrix localPointToGlobal: (aBoolean ifFalse:[0@0] ifTrue:[-16384@0]).
	direction := (gradientMatrix localPointToGlobal: (16384@0)) - origin.
	normal := (gradientMatrix localPointToGlobal: (0@16384)) - origin.
	fillStyle := GradientFillStyle ramp: ramp.
	fillStyle origin: origin.
	fillStyle direction: direction.
	fillStyle normal: normal.
	fillStyle radial: aBoolean not.
	fillStyle pixelRamp. "Force creation beforehand"
	fillStyles at: fillIndex put: fillStyle.